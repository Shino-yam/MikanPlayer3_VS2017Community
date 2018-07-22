using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MikanPlayer3
{
    class PlayMP3
    {

        // mp3再生関連の設定変数
        private int volume = 0;

        // Windows Media Player を利用する準備（.NET Framework 4以上対応）
        // 参照url　https://qiita.com/fujieda/items/d8642eae891d096d4028
        // 参照url　https://msdn.microsoft.com/ja-jp/library/cc429720.aspx
        private readonly dynamic _wmp = Activator.CreateInstance(Type.GetTypeFromProgID("WMPlayer.OCX.7"));


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PlayMP3()
        {

            this.volume = _wmp.Settings.volume;
        }


        /// <summary>
        /// 音量のsetter/getter
        /// </summary>
        /// <param name="vol"></param>
        public void SetVolume(int vol)
        {
            this.volume = vol;
            _wmp.Settings.volume = vol;
        }
        public int GetVolume()
        {
            return this.volume;
        }
        

        /// <summary>
        /// 再生
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Boolean Play(string filePath)
        {
            // 再生開始

            _wmp.URL = filePath;
            _wmp.Controls.play();

            return true;
        }


        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        public Boolean Stop()
        {
            //再生しているmp3を停止する
            _wmp.Controls.stop();

            return true;
        }


        /// <summary>
        /// 再生状態の取得
        /// </summary>
        /// <returns></returns>
        public Boolean isPlayEnd()
        {
            int state = _wmp.Play.playstate;

            if ( state != 8 )
            {
                return false;
            }
            return true;
        }

    }
}
