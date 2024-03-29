﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    internal class MoveStateControl
    {
        private Character _owner;
        private CharMoveState _moveState;
        private ushort _angle;
        private uint _currentFieldCode;
        private ushort _currentTileID;
        private uint _currentSectorID;
        private bool _isMoving;
        private float _baseMoveSpeed;
        private SunVector? _destinationPos;
        private long _lastTick;

        public MoveStateControl(Character owner, CharMoveState moveState)
        {
            _owner = owner;
            SetMoveState(moveState);
        }

        public void Update(long tick)
        {
            if (_destinationPos !=null && _owner.GetStatusManager().CanMove())
            {
                if (SunVector.GetDistance(_destinationPos, _owner.GetPos()) < 0.5f)
                {
                    _destinationPos = null;
                    _isMoving = false;
                    return;
                }
                var ms =(int)  ((tick - _lastTick)/TimeSpan.TicksPerMillisecond);
                var orgPos = _owner.GetPos();
                var direction = _destinationPos - orgPos;
                direction.Normalize();
                var distance = direction * GetMoveSpeed() * ms ;
                _owner.SetPos(orgPos+distance);
                Logger.Instance.Log($"[{orgPos}] [{orgPos+distance}] [{_destinationPos}]");
            }
            _lastTick = tick;
        }
        public CharMoveState GetMoveState() { return _moveState; }

        public void SetMoveState(CharMoveState moveSate)
        {
            _moveState = moveSate;
            if (_owner.IsObjectType(ObjectType.PLAYER_OBJECT))
            {
                _baseMoveSpeed = NumericValues.GetBaseMoveSpeedAsState(moveSate);
            }
            else if (_owner is NPC npc)
            {
                switch (moveSate)
                {
                    case CharMoveState.CMS_WALK:
                        _baseMoveSpeed = npc.GetBaseInfo().WalkSpeed * Const.SPEED_MULTIPLIER;
                        break;
                    case CharMoveState.CMS_RUN:
                        _baseMoveSpeed = npc.GetBaseInfo().RunSpeed * Const.SPEED_MULTIPLIER;
                        break;
                    default:
                        _baseMoveSpeed = NumericValues.GetBaseMoveSpeedAsState(_moveState);
                        break;
                }
            }
        }

        public float GetMoveSpeed()
        {
            float moveSpeed = _baseMoveSpeed;
            if (_owner is Player player)
            {
                var addRatio = player.GetMoveSpeedRatio();

                moveSpeed *= addRatio;
            }

            return moveSpeed;
        }

        public bool IsMoving()
        {
            return _isMoving;
        }

        public void SetFieldCode(uint fieldCode)
        {
            _currentFieldCode = fieldCode;
        }

        public void SetAngle(ushort angle)
        {
            _angle = angle;
        }

        public void SetTileID(ushort tileID)
        {
            _currentTileID = tileID;
        }

        public uint GetCurrentMapCode()
        {
            return _currentFieldCode;
        }

        public void SetSectorID(uint sectorID)
        {
            _currentSectorID = sectorID;
        }

        public uint GetSectorID()
        {
            return _currentSectorID;
        }

        public void SetNewDestinationPos(SunVector pos)
        {
            _destinationPos = pos;
            _isMoving = true;
        }
    }
}
