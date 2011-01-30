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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Text;

namespace TooCuteToLive
{
    class AnimatedSprite
    {
        /* Number of frames the animation has */
        private int mFrameCount;

        /* Frames Per Second */
        private float mFPS, mScale;

        /* The current frame to show */
        private int mFrame;

        private Texture2D mTexture;

        /* Elapsed time */
        private float mElapsed;

        public float Scale
        {
            get {return mScale;}
            set {mScale = value;}
        }

        public AnimatedSprite() { }

        /// <summary>
        /// Loads function - self explanatory
        /// </summary>
        /// <param name="content">The current content manager</param>
        /// <param name="name">Name of the asset - assumes the animatedSprites folder</param>
        /// <param name="frameCount">number of frames</param>
        /// <param name="FPS">Frames Per Second</param>
        public void Load(ContentManager content, string name, int frameCount, float FPS)
        {
            mFrameCount = frameCount;
            mTexture = content.Load<Texture2D>(name);
            mFPS = FPS;
            mFrame = 0;
            mElapsed = 0.0f;
            mScale = 0.5f;
        }

        /// <summary>
        /// Update function - self explanatory
        /// </summary>
        /// <param name="elapsed">elapsed time - use (float)gameTime.ElapsedGameTime.TotalSeconds</param>
        public void Update(float elapsed)
        {
            mElapsed += elapsed;

            /* If enough has passed, update the frame */
            if (mElapsed > mFPS)
            {
                mFrame++;

                mFrame = mFrame % mFrameCount;
                mElapsed -= mFPS;
            }
        }

        /// <summary>
        /// Draw function - self explanatory
        /// </summary>
        /// <param name="spriteBatch">the spritebatch to draw</param>
        /// <param name="position">where you want the texture to be drawn</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = mTexture.Width / mFrameCount;
            Rectangle sourcerect = new Rectangle(width * mFrame, 0, width, mTexture.Height);

            spriteBatch.Draw(mTexture, position, sourcerect, Color.White, 0.0f, Vector2.Zero, mScale, SpriteEffects.None, 0.0f);

        }

        /// <summary>
        /// Reset function - Resets the frames and elapsed time to zero
        /// </summary>
        public void Reset()
        {
            mFrame = 0;
            mElapsed = 0.0f;
        }

        public float getHeight()
        {
            return mTexture.Height*mScale;
        }

        public float getWidth()
        {
            return (mTexture.Width / mFrameCount)*mScale;
        }
    }
}
