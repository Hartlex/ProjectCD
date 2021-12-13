using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter
{
    public class Character : ObjectBase
    {
        public virtual ushort GetSTR(){return 0;}
        public virtual ushort GetVIT(){return 0;}
        public virtual ushort GetDEX(){return 0;}
        public virtual ushort GetINT(){return 0;}
        public virtual ushort GetSPR(){return 0;}

        public virtual uint GetHP() {return 0; }
        public virtual uint GetMP() {return 0; }
        public virtual uint GetMaxHP() {return 0; }
        public virtual uint GetMaxMP() {return 0; }
    }
}
