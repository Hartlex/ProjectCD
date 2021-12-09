using System.Numerics;
using CDShared.ByteLevel;

namespace SunStructs.ServerInfos.General
{
    public class SunVector
    {
        private Vector3 _vector;
        public SunVector(float posX, float posY, float posZ)
        {
            _vector = new Vector3(posX, posY, posZ);
        }
        public SunVector(Vector3 vector,bool twoDim=false)
        {
            _vector = twoDim ? new Vector3(vector.X, vector.Y, 0) : vector;
        }
        public SunVector(ref ByteBuffer buffer)
        {
            var posX = buffer.ReadFloat();
            var posY = buffer.ReadFloat();
            var posZ = buffer.ReadFloat();
            _vector = new Vector3(posX, posY, posZ);
        }
        public float GetX(){return _vector.X;}
        public float GetY(){return _vector.Y;}
        public float GetZ(){return _vector.Z;}
        public byte[] GetBytes()
        {
            ByteBuffer buffer = new ByteBuffer(4);
            GetBytes(ref buffer);
            return buffer.GetData();
        }
        public void ToTwoDim()
        {
            _vector = new Vector3(_vector.X, _vector.Y, 0);
        }
        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteFloat(_vector.X);
            buffer.WriteFloat(_vector.Y);
            buffer.WriteFloat(_vector.Z);
        }
        public float GetLength()
        {
            return _vector.Length();
        }
        //TODO REMOVE GETLENGTH2
        public float GetLength2()
        {
            return MathF.Sqrt(GetLength());
        }
        public float VectorLength()
        {
            return GetLength2();
        }
        public void Normalize()
        {
            _vector = Vector3.Normalize(_vector);
        }

        public override string ToString()
        {
            return "X: " + GetX().ToString(".0#") + " Y: " + GetY().ToString(".0#") + " Z: " + GetZ().ToString(".0#");
        }

        public static SunVector GetRandomPosAround(SunVector pos, float area)
        {

            var r = area * Math.Sqrt(GlobalRand.Instance.RandomDouble());
            var t = GlobalRand.Instance.RandomDouble() * 2 * Math.PI;
            
            return new SunVector(
                (float) (r * Math.Cos(t) + pos.GetX()),
                (float) (r * Math.Sin(t) + pos.GetY()),
                pos.GetZ()
            );
        }
        public static SunVector GetDistanceVector(SunVector v1, SunVector v2)
        {
            return new SunVector(v1._vector - v2._vector);
        }
        public static int GetAngle(SunVector v)
        {
            var vn = Vector3.Normalize(v._vector);
            var angle = (int)MathF.Acos(vn.X);
            if (vn.Y < 0)
            {
                return 360 - angle;
            }

            return angle;

        }
        public static SunVector operator *(SunVector v1, SunVector v2)
        {
            return new (v1._vector * v2._vector);
        }
        public static SunVector operator *(SunVector v1, float multValue)
        {
            return new (v1._vector * multValue);
        }
        public static SunVector operator +(SunVector v1, SunVector v2)
        {
            return new SunVector(v1._vector + v2._vector);
        }
        public static SunVector operator -(SunVector v1, SunVector v2)
        {
            return new SunVector(v1._vector - v2._vector);
        }
        public static bool IsPositionInFanShapedArea(SunVector targetPos, SunVector attackerPos, SunVector mainTargetDirVector,int srcAngle)
        {
            SunVector targetVec = targetPos - attackerPos;
            SunVector mainTargetDir = mainTargetDirVector;
            targetVec.ToTwoDim();
            mainTargetDir.ToTwoDim();

            targetVec.Normalize();
            mainTargetDir.Normalize();

            float inner = targetVec.GetX() * mainTargetDir.GetX() + targetVec.GetY() * mainTargetDir.GetY();
            return (inner >= MathF.Cos(srcAngle / 2)) || inner == 0;

        }
        public static bool IsPositionInObb(SunVector start, SunVector end, float width, SunVector target)
        {
            var diff = start - end;
            var center = (start + end) * 0.5f;

            diff.ToTwoDim();
            center.ToTwoDim();


            if (diff.GetX() == 0 && diff.GetY() == 0) return false;
            var length = diff.VectorLength();
            diff.Normalize();

            float axis1X = diff.GetX();
            float axis1Y = diff.GetY();

            float axis2X = diff.GetY();
            float axis2Y = diff.GetX();

            var offset = target - center;

            float newAxisX = -(offset.GetX() * axis2Y + offset.GetY() * -axis1Y);
            float newAxisY = -(offset.GetX() * -axis2X + offset.GetY() * axis1X);

            float det = axis1X * axis2Y - axis1Y * axis2X;

            if (!(MathF.Abs(newAxisX) <= length * 0.5f)) return false;
            return MathF.Abs(newAxisY) <= width * 0.5f;
        }
        public static float GetDistance(SunVector v1,SunVector v2)
        {
            return Vector3.Distance(v1._vector, v2._vector);
        }
    }
}
