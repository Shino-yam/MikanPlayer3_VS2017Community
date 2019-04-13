using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikanPlayer3
{
    public partial class FormMain : Form
    {
        // MikanPlayer3Main のためのオブジェクト
        private MikanPlayerMain mp3Main = new MikanPlayerMain();

        // ThreadPlayContgroller のためのオブジェクト
        private ThreadPlayController threadPlayer = new ThreadPlayController();

        // プレイリストがカラの時の文字列
        private const string EMPTY_PLAYLIST_MESSAGE01 = "*** プレイリストにファイルがありません。";
        private const string EMPTY_PLAYLIST_MESSAGE02 = "*** 「プレイリストに追加」で，ファイルを追加してください。";
        //private const string EMPTY_PLAYLIST_MESSAGE03 = "*** 1曲再生毎に停止するのは仕様です。 次の曲を自動再生するように要改良。";

        // プレイリストがカラかどうかのフラグ
        private Boolean isEmptyPlayList = true;

        // プレイリストに追加開始しているかどうかのフラグ
        private Boolean isAddPlayList = false;

        //// 再生中かどうかのフラグ
        //private Boolean isPlaying = false;

        // プレイリストの最大index保持用
        private int maxIndex = 0;

        // プレイリストの現在のindex保持用
        private int nowIndex = 0;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            
            // プレイリストの初期化
            InitPlayList();

            //// 音量の初期化
            //// デフォルトで50になっている？
            int nowVolume = mp3Main.getVolume();
            threadPlayer.setVolume(nowVolume);
            //mp3Main.SetVolume(nowVolume);
            trackBarVolume.Value = nowVolume;

            //
            threadPlayer.SetFormMain(this);

        }


        /// <summary>
        /// プレイリスト初期化
        /// </summary>
        private void InitPlayList()
        {
            if (isEmptyPlayList)
            {
                // プレイリストがカラのときは，その旨メッセージを表示，無効化する
                listBoxPlayList.Items.Clear();
                listBoxPlayList.Items.Add(EMPTY_PLAYLIST_MESSAGE01);
                listBoxPlayList.Items.Add(EMPTY_PLAYLIST_MESSAGE02);
                //listBoxPlayList.Items.Add(EMPTY_PLAYLIST_MESSAGE03);
                listBoxPlayList.Enabled = false;
                isAddPlayList = false;

                // データオブジェクトのプレイリストをクリア
                mp3Main.PlayListClear();

                // ロゴを表示する
                panelImg.Visible = true;

                // ボタンを無効化する
                this.SetButtonState(false);
            }
            else
            {
                // プレイリストがカラでないときは，有効化する
                if (!isAddPlayList)
                {
                    // 追加でないとき（カラメッセージ）のときはクリアする
                    listBoxPlayList.Items.Clear();

                    // データオブジェクトのプレイリストをクリア
                    mp3Main.PlayListClear();

                    // ロゴを消す
                    panelImg.Visible = false;

                    // ボタンを有効化する
                    this.SetButtonState(true);
                }
                listBoxPlayList.Enabled = true;
                isAddPlayList = true;
            }

        }
        

        /// <summary>
        /// プレイリストの表示更新
        /// </summary>
        private void updatePlayList(string func, List<string> files)
        {
            // プレイリストがカラであれば処理をやめる
            if(isEmptyPlayList)
            {
                return;
            }

            // 追加でなければプレイリストをクリアする
            if( func != "ADD")
            {
                listBoxPlayList.Items.Clear();
            }

            // プレイリストに追加する
            int max = files.Count;
            for (int i = 0; i < max; i++)
            {
                listBoxPlayList.Items.Add(files[i]);
            }

            // 削除のときはindexを更新する
            if( func == "DEL" )
            {
                int tempIndex = nowIndex; 
                getIndex();
                nowIndex = tempIndex;
            }

            if (nowIndex < 0)
            {
                nowIndex = 0;
            }
            else if(nowIndex > maxIndex)
            {
                nowIndex = maxIndex;
            }
            
            listBoxPlayList.SelectedIndex = this.nowIndex;

            threadPlayer.SetPlayList(files);
        }




        /// <summary>
        /// データオブジェクトから，各indexを取得する
        /// </summary>
        private void getIndex()
        {
            //this.nowIndex = mp3Main.getNowIndex();
            this.nowIndex = listBoxPlayList.SelectedIndex;
            this.maxIndex = mp3Main.getMaxIndex();
        }


        /// <summary>
        /// プレイリスト機能ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFileFunction_Click(object sender, EventArgs e)
        {
            // indexを取得
            getIndex();

            // 押下されたボタン名を取得
            string buttonId = ((Button)sender).Name;

            // 押下されたボタンに応じた処理
            switch (buttonId)
            {
                // ファイル選択
                case "buttonFileSelect":

                    // 複数選択可能なダイアログでファイルを選択する
                    List<string> rawFiles = this.FileSelect();
                    int max = rawFiles.Count;
                    if(max > 0)
                    {
                        isEmptyPlayList = false;
                        InitPlayList();
                    }

                    // プレイリストの末尾に追加する
                    updatePlayList("ADD", rawFiles);

                    //
                    mp3Main.PlayListAdd(rawFiles);

                    break;

                // プレイリスト全削除
                case "buttonPlayListDeleteAll":

                    // 確認ダイアログを表示
                    DialogResult result = MessageBox.Show(
                        "プレイリストを全て削除しますか？",
                        "確認",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2
                    );

                    if(result == DialogResult.Yes)
                    {
                        // 「はい」選択のとき
                        isEmptyPlayList = true;
                        InitPlayList();
                    }

                    threadPlayer.SetPlayList(null);

                    break;

                // プレイリスト1件削除
                case "buttonPlayListDeleteOnce":

                    // TODO: リストから1件削除
                    if(!isEmptyPlayList)
                    {
                        // 1件削除
                        mp3Main.PlayListDel(nowIndex);

                        List<string> allPlayList = mp3Main.getAllPlayList();

                        updatePlayList("DEL", allPlayList);

                        if (allPlayList.Count == 0)
                        {
                            this.isEmptyPlayList = true;
                            InitPlayList();
                            return;
                        }
                    }
                    break;

                // 上へ移動
                case "buttonPlayListUp":

                    // TODO: 1つ上のリストとスワップ
                    if (nowIndex > 0)
                    {
                        mp3Main.swapIndex(nowIndex, (nowIndex - 1));
                        nowIndex--;
                    }

                    updatePlayList("NEW", mp3Main.getAllPlayList());

                    break;

                // 下へ移動
                case "buttonPlayListDown":

                    // TODO: 1つ下のリストとスワップ
                    if (nowIndex < maxIndex)
                    {
                        mp3Main.swapIndex(nowIndex, (nowIndex + 1));
                        nowIndex++;
                    }

                    updatePlayList("NEW", mp3Main.getAllPlayList());

                    break;

                default:
                    break;
                
            }

        }


        /// <summary>
        /// 再生機能ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayFunction_Click(object sender, EventArgs e)
        {
            // 押下されたボタン名を取得
            string buttonId = ((Button)sender).Name;

            // indexを取得
            getIndex();

            // 押下されたボタンに応じた処理
            switch (buttonId)
            {
                // 再生
                case "buttonPlay":

                    string playFile = mp3Main.getPlayFile(nowIndex);

                    // メディア情報の表示
                    DisplayInfo(playFile);
                    //List<string> infoData = mp3Main.getInfo(playFile); ;

                    //string[] infoTitle = {
                    //    "アーティスト： ",
                    //    "タイトル： ",
                    //    "ジャンル： ",
                    //    "コメント： ",
                    //    "アルバム： ",
                    //    "年： "
                    //};

                    //string infoStr = "";
                    //for (int i = 0; i < infoData.Count; i++)
                    //{
                    //    infoStr += infoTitle[i] + infoData[i] + "\r\n";
                    //}

                    //textBoxMp3Data.Text = infoStr;

                    // 再生
                    threadPlayer.SetPlayFile(playFile);





                    //// ファイル再生メソッド呼び出し
                    //List<string> infoData = mp3Main.Play(nowIndex);

                    //// メディア情報の表示
                    //string[] infoTitle = {
                    //    "アーティスト： ",
                    //    "タイトル： ",
                    //    "ジャンル： ",
                    //    "コメント： ",
                    //    "アルバム： ",
                    //    "年： "
                    //};

                    //string infoStr = "";
                    //for( int i = 0; i < infoData.Count; i++ )
                    //{
                    //    infoStr += infoTitle[i] + infoData[i] + "\r\n";
                    //}

                    //textBoxMp3Data.Text = infoStr;

                    break;

                // 停止
                case "buttonStop":

                    threadPlayer.SetPlayFile("");



                    // 再生停止メソッド呼び出し
                    threadPlayer.PushStopButton();
                    //this.isPlaying = !mp3Main.Stop();

                    textBoxMp3Data.Text = "*** 再生を停止しています ***";

                    break;

                // 前の曲へ
                case "buttonReverse":

                    // TODO: リスト戻しメソッド呼び出し
                    if(!isEmptyPlayList)
                    {
                        this.nowIndex = mp3Main.Index("REV", nowIndex);
                        listBoxPlayList.SelectedIndex = nowIndex;
                    }
                    break;

                // 次の曲へ
                case "buttonForward":

                    // TODO: リスト送りメソッド呼び出し
                    if (!isEmptyPlayList)
                    {
                        this.nowIndex = mp3Main.Index("FF", nowIndex);
                        listBoxPlayList.SelectedIndex = nowIndex;
                    }
                    break;

                default:
                    break;

            }

        }


        /// <summary>
        /// MP3ファイルを開く（複数選択可）
        /// </summary>
        /// <returns></returns>
        public List<string> FileSelect()
        {
            List<string> selectedFiles = new List<string>();

            openFileDialogMulti.Title = "ファイルを開きます(複数選択可)";
            openFileDialogMulti.Multiselect = true;
            openFileDialogMulti.Filter = "mp3ファイル(*.mp3)|*.mp3";
            openFileDialogMulti.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            //
            if (openFileDialogMulti.ShowDialog() == DialogResult.OK)
            {
                foreach(string fileName in openFileDialogMulti.FileNames)
                {
                    selectedFiles.Add(fileName);
                }

            }

            return selectedFiles;

        }


        /// <summary>
        /// プレイリストの選択が変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nowIndex = listBoxPlayList.SelectedIndex;

        }


        /// <summary>
        /// 情報表示
        /// </summary>
        public void DisplayInfo(string filePath)
        {
            List<string> infoData = mp3Main.getInfo(filePath); ;

            string[] infoTitle = {
                "アーティスト： ",
                "タイトル： ",
                "ジャンル： ",
                "コメント： ",
                "アルバム： ",
                "年： "
            };

            string infoStr = "";
            for (int i = 0; i < infoData.Count; i++)
            {
                infoStr += infoTitle[i] + infoData[i] + "\r\n";
            }

            textBoxMp3Data.Text = infoStr;

        }


        /// <summary>
        /// 音量の設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            int volumeSetting = trackBarVolume.Value;

            threadPlayer.setVolume(volumeSetting);

            //mp3Main.SetVolume(volumeSetting);
        }


        /// <summary>
        /// プレイリストの指定されたindexを選択する
        /// </summary>
        /// <param name="index"></param>
        public void SelectPlayList(int index)
        {
            //FormMain frm = new FormMain();
            listBoxPlayList.SelectedIndex = index;
        }


        /// <summary>
        /// ボタン状態を設定する
        /// </summary>
        /// <param name="isEnable">true:Enable</param>
        public void SetButtonState(bool isEnable)
        {
            this.buttonReverse.Enabled = isEnable;
            this.buttonPlay.Enabled = isEnable;
            this.buttonStop.Enabled = isEnable;
            this.buttonForward.Enabled = isEnable;
        }



    }
}
