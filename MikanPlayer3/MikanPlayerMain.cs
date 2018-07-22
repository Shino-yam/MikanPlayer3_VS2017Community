using Shell32;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikanPlayer3
{
    
    class MikanPlayerMain
    {
        // FormMain のオブジェクト
        private FormMain frm = null;

        // mp3データオブジェクト
        private DataObjectMP3 mp3DO = new DataObjectMP3();

        // mp3再生クラス
        private PlayMP3 mp3 = new PlayMP3();

        // 再生中フラグ
        private Boolean isNowPlaying = false;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="frm"></param>
        public MikanPlayerMain()
        {
            //
        }
        

        /// <summary>
        /// プレイリストの全取得
        /// </summary>
        /// <returns></returns>
        public List<string> getAllPlayList()
        {
            return mp3DO.getAllFilePath();
        }


        /// <summary>
        /// プレイリストの全削除
        /// </summary>
        public void PlayListClear()
        {
            mp3DO.clearFilePath();
            mp3DO.setMaxIndex();
        }


        /// <summary>
        /// プレイリストの1件削除
        /// </summary>
        public void PlayListDel(int index)
        {
            mp3DO.delFilePath(index);
            mp3DO.setMaxIndex();
        }


        /// <summary>
        /// プレイリストへの追加
        /// </summary>
        /// <param name="files"></param>
        public void PlayListAdd(List<string> files)
        {
            int max = files.Count;

            for(int i = 0; i < max; i++)
            {
                mp3DO.addFilePath(files[i]);
            }

            mp3DO.setMaxIndex();
        }


        /// <summary>
        /// 選択中のindexを返す
        /// </summary>
        /// <returns></returns>
        public int getNowIndex()
        {
            return mp3DO.getNowPlayIndex();
        }


        /// <summary>
        /// 最大indexを返す
        /// </summary>
        /// <returns></returns>
        public int getMaxIndex()
        {
            return mp3DO.getMaxIndex();
        }


        /// <summary>
        /// プレイリストのスワップ
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public void swapIndex(int index1, int index2)
        {
            mp3DO.swap(index1, index2);
        }



        /// <summary>
        /// プレイリストindexの操作
        /// </summary>
        /// <param name="func"></param>
        /// <param name="isEmptyPlayList"></param>
        /// <returns></returns>
        public int Index(string func, int now)
        {
            // indexの最大値を取得
            int max = mp3DO.getMaxIndex();
            
            // プレイリストがカラの時は処理をやめる
            if(max == 0)
            {
                return now;
            }

            // 機能に応じた処理
            int ret = now;

            switch(func)
            {
                // 前のindexへ移動
                case "REV":
                    if ((max > 0) && (now > 0))
                    {
                        ret--;
                    }
                    break;

                // 次のindexへ移動
                case "FF":
                    if (max > now)
                    {
                        ret++;
                    }
                    break;

                default:
                    break;

            }

            // データオブジェクトへの登録
            mp3DO.setNowPlayIndex(ret);

            return ret;
        }


        /// <summary>
        /// 再生
        /// </summary>
        /// <param name="index"></param>
        public List<string> Play(int index)
        {
            // 現在，再生中であれば停止
            if(isNowPlaying)
            {
                mp3.Stop();
                this.isNowPlaying = false;
            }

            // index からファイル名を取得
            string filePath = mp3DO.getFilePath(index);
            mp3DO.setNowPlayIndex(index);

                        // ファイル存在チェック，ファイルが存在しなければ処理をやめる
            Boolean isFileExist = System.IO.File.Exists(filePath);
            if(!isFileExist)
            {
                return null;
            }

            // 再生中フラグのセット
            this.isNowPlaying = true;

            // mp3情報を取得
            List<string> ret = new List<string>();

            Shell32.Shell shell = new Shell32.Shell();
            string fileName = System.IO.Path.GetFileName(filePath);
            string path = filePath.Replace(fileName, "");

            Folder f = shell.NameSpace(path);
            FolderItem item = f.ParseName(fileName);

            // ※下記の設定は Windows10 のもの
            //
            ret.Add(f.GetDetailsOf(item, 13)); // アーティスト情報
            ret.Add(f.GetDetailsOf(item, 21)); // タイトル情報
            ret.Add(f.GetDetailsOf(item, 16)); // ジャンル情報
            ret.Add(f.GetDetailsOf(item, 24)); // コメント情報
            ret.Add(f.GetDetailsOf(item, 14)); // アルバムタイトル情報
            ret.Add(f.GetDetailsOf(item, 15)); // 年情報

            mp3.Play(filePath);

            return ret;
        }


        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            // 現在，再生していなければ処理をやめる
            if(!isNowPlaying)
            {
                return;
            }

            // 再生中フラグのリセット
            this.isNowPlaying = false;

            mp3.Stop();

        }


        /// <summary>
        /// 再生状態の取得
        /// </summary>
        /// <returns></returns>
        public Boolean playState()
        {
            return mp3.isPlayEnd();
        }


        /// <summary>
        /// 音量設定
        /// </summary>
        /// <param name="vol"></param>
        public void setVolume(int vol)
        {
            mp3.SetVolume(vol);
        }
        public int getVolume()
        {
            return mp3.GetVolume();
        }

    }
}
