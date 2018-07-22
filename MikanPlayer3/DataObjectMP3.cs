using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikanPlayer3
{
    class DataObjectMP3
    {
        // プレイリストに関する変数
        private int maxIndex = 0;                           // プレイリスト最大index
        private int nowPlayIndex = 0;                       // 現在再生中のindex

        // mp3ファイルに関するデータ格納用変数
        private List<string> filePath = new List<string>(); // mp3ファイルのパス（プレイリスト）


        /// <summary>
        /// 最大indexのsetter/getter
        /// </summary>
        /// <param name="index"></param>
        public void setMaxIndex()
            {
                int max = filePath.Count - 1; // 自動計算
                this.maxIndex = max;
            }
            public int getMaxIndex()
            {
                return this.maxIndex;
            }


        /// <summary>
        /// 現在再生中のindexのsetter/getter
        /// </summary>
        public void setNowPlayIndex(int index)
        {
            this.nowPlayIndex = index;

        }
        public int getNowPlayIndex()
        {
            return this.nowPlayIndex;
        }


        /// <summary>
        /// ファイルパスのsetter/getter/delete/swap
        /// </summary>
        /// <param name="index"></param>
        /// <param name="path"></param>
        public void setFilePath(int index, string path)
        {
            this.filePath[index] = path;
        }
        public string getFilePath(int index)
        {
            if ( index < 0 )
            {
                return null;
            }
            return this.filePath[index];

        }
        public List<string> getAllFilePath()
        {
            return this.filePath;
        }
        public void addFilePath(string path)
        {
            this.filePath.Add(path);
        }
        public void delFilePath(int index)
        {
            if(index < 0)
            {
                return;
            }
            this.filePath.RemoveAt(index);
        }
        public void clearFilePath()
        {
            this.filePath.Clear();
        }
        public void swap(int index1, int index2)
        {
            string temp = this.filePath[index1];
            this.filePath[index1] = this.filePath[index2];
            this.filePath[index2] = temp;
        }

    }
}
