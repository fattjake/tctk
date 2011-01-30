﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TooCuteToLive
{
    class WeaponEffects
    {
        private float mTimeleft;
    }

    class WeaponManager
    {
        private List<WeaponEffects> mElist;

        private List<Weapon> mWlist;

        private int mCurwep;

        public WeaponManager(ContentManager cm, GraphicsDeviceManager gm)
        {
            mCurwep = 0;
            /* Add Weapons here */
            mWlist = new List<Weapon>();
            mElist = new List<WeaponEffects>();

            mWlist.Add(new Weapon("rainbow", cm, gm));
        }

        public void UseCur(Vector2 pos, int mousey)
        {
            mWlist[mCurwep].Strike(pos, 1, mousey);
            Console.WriteLine("Striking at " + pos.X + " " + pos.Y);
        }

        public void Update(GameTime gt)
        {
            /* XXX */
            mWlist[mCurwep].Update(gt, 0);
        }

        public void Draw(SpriteBatch sb)
        {
            /* XXX */
            mWlist[mCurwep].Draw(sb);
        }
    }
}
