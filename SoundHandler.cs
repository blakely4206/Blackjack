using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Blackjack
{
    class SoundHandler
    {
       
        [DllImport("winmm.dll")]
        
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
        internal bool isMute;
        [Test]
        internal void Run_Music()
        {
            try
            {
               
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Resources\intro.mp3";
                mciSendString(@"open " + path + " type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                Assert.Fail();
            }
            catch
            { }
        }
        
        internal void Mute()
        {
            if (isMute == false)
            {
                mciSendString("pause MediaFile", null, 0, IntPtr.Zero);
                isMute = true;
            }
            else
            {
                mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                isMute = false;
            }
        }

        internal void Play_Bust_Sound()
        {
            if (isMute == false)
            {
                sp.Stream = ddd3d.bust;
             
                sp.Play();
            }
        }

        internal void Play_Shuffle()
        {
            if (isMute == false)
            {
                sp.Stream = ddd3d.cardShuffle;
                sp.Play();
            }
        }
    }
}
