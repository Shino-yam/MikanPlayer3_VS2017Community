using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MikanPlayer3
{
    class ThreadPlayController
    {
        // 再生するmp3のファイルパス
        private string playFile = "";

        // 現在再生中のmp3のファイルパス
        private string nowPlayFile = "";

        // プレイリスト取得変数
        private List<string> playList = new List<string>();

        // 再生中フラグ
        private Boolean isPlaying = false;

        // 「停止」ボタン押下フラグ
        private Boolean isStopButton = false;

        // ループ再生かどうかのフラグ
        private Boolean isLoop = true;

        // PlayMP3 のインスタンス化
        private PlayMP3 mp3 = new PlayMP3();

        // FormMain のインスタンス化用変数
        FormMain frm = null;

        // FormMain制御，プレイリストのカーソル位置変更
        private delegate void SendSelectPlayList(int index);

        // FormMain制御，メディア情報の表示
        private delegate void SendDisplayInfo(string filePath);

        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ThreadPlayController()
        {
            // PlayerMain() をスレッドとして実行する
            Thread th = new Thread(new ThreadStart(this.PlayerMain));
            th.IsBackground = true;
            th.Start();
        }


        /// <summary>
        /// FormMain のインスタンス受け取り
        /// </summary>
        public void SetFormMain(FormMain frmMain)
        {
            this.frm = frmMain;
        }


        /// <summary>
        /// プレイリストの受け取り
        /// </summary>
        public void SetPlayList(List<string> pList)
        {
            this.playList = pList;

            if(pList == null)
            {
                this.nowPlayFile = "";
                this.playFile = "";
            }
        }


        /// <summary>
        /// playFile のsetter
        /// </summary>
        /// <param name="file"></param>
        public void SetPlayFile(string file)
        {
            this.playFile = file;
        }

        /// <summary>
        /// 「停止」ボタン押下
        /// </summary>
        public void PushStopButton()
        {
            this.isStopButton = true;
        }


        /// <summary>
        /// 音量の設定
        /// </summary>
        public void setVolume(int vol)
        {
            mp3.SetVolume(vol);
        }


        /// <summary>
        /// 次のプレイリスト再生
        /// </summary>
        public void PlayNext()
        {
            // 自前で持っているプレイリストを参照
            // 最大index，現index を取得

            int maxIndex = this.playList.Count - 1;
            int idx = this.playList.IndexOf(this.nowPlayFile);

            int nowIndex = 0;
            if(idx != -1)
            {
                nowIndex = idx;
            }

            if( nowIndex < maxIndex )
            {
                // 次のファイルを再生（ファイルのセット）
                nowIndex++;
                this.playFile = this.playList[nowIndex];

                // スレッドからFormMainの制御
                
                // メディア情報，プレイリストのカーソル位置変更
                frm.Invoke(new SendDisplayInfo(frm.DisplayInfo), this.playFile);
                frm.Invoke(new SendSelectPlayList(frm.SelectPlayList), nowIndex);

            }
            else
            {
                // 再生をやめる
                isLoop = false;

            }

        }





        /// <summary>
        /// スレッドメイン処理
        /// </summary>
        public void PlayerMain()
        {
            while(true)
            {

                Boolean isPlayEnd = mp3.IsPlayEnd();
                Thread.Sleep(300);

                if (!this.isPlaying)
                {
                    // 再生中でない場合

                    // 再生するファイルのパスを取得
                    string file = this.playFile;

                    // ファイルが設定されていれば再生
                    if(file.Length != 0)
                    {
                        mp3.Play(file);

                        this.isPlaying = true;
                        this.isLoop = true;
                        this.isStopButton = false;
                        this.nowPlayFile = file;
                    }
                }
                else
                {
                    // 再生中の場合

                    if(isPlayEnd || (this.playFile != this.nowPlayFile))
                    {
                        isPlayEnd = true;
                    }
                    else if(this.playFile.Length == 0)
                    {
                        isPlayEnd = true;
                        isLoop = false;
                    }

                    // 再生停止
                    if(isPlayEnd || isStopButton)
                    {
                        mp3.Stop();

                        this.isPlaying = false;

                        if(this.playFile == this.nowPlayFile)
                        {
                            this.playFile = "";
                        }

                        if(!isLoop)
                        {
                            this.nowPlayFile = "";
                        }
                    }

                    // ループ再生の時の処理
                    if (isLoop && isPlayEnd && !isStopButton)
                    {
                        isPlaying = false;

                        PlayNext();
                    }

                }





            }
        }


    }
}
