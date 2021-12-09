using System.Data.SqlClient;

namespace SunStructs.ServerInfos.General.Object.Character.Player
{
    /// <summary>
    /// Contains information to render a character like heightCode, faceCode and hairCode.
    /// </summary>
    public class BaseCharacterRenderInfo
    {
        public readonly byte HeightCode;
        public readonly byte FaceCode;
        public readonly byte HairCode;

        /// <summary>
        /// Creates an Object of Type BasePlayerRenderInfo
        /// </summary>
        /// <param name="heightCode">The heightCode of the player</param>
        /// <param name="faceCode">The faceCode of the player</param>
        /// <param name="hairCode">The hairCode of the player</param>
        public BaseCharacterRenderInfo(byte heightCode, byte faceCode, byte hairCode)
        {
            HeightCode = heightCode;
            FaceCode = faceCode;
            HairCode = hairCode;
        }

        public BaseCharacterRenderInfo(ref SqlDataReader reader)
        {
            HeightCode = reader.GetByte(5);
            FaceCode = reader.GetByte(6);
            HairCode = reader.GetByte(7);
        }
    }
}