using Git_Complete.src.entity;
using Git_Complete.src.exception;
using System;
using System.Collections.Generic;

namespace Git_Complete.src.parser
{
    class GitEntityParser
    {
        /// <summary>
        /// sinopsisの共通整形。整形のルールは下記を参照。（基本的にLinuxのmanページのsynopsisと同じ形式。斜め文字や太字でのルールはない）
        /// ※synopsisに共通的なルールはないため、いったんGitのsynopsisをベースに整形する。
        /// <see cref="https://qiita.com/mather314/items/a53da94359d54443bcdc"/>
        /// </summary>
        /// <param name="_in"></param>
        /// <returns></returns>
        private ECommandKeyScrape ShapSynopsisCommon(ECommandKeyScrape _in)
        {
            //まずは。。。。


            //test
            return _in;
        }

        /// <summary>
        /// sinopsisの共通整形呼び出しサブルーチン。
        /// 利用側では主にリストをメインで処理を行うので、下記を定義。
        /// 引数は直接使用しない（引数に対して変更を行わない）
        /// 
        /// <see cref="ShapSynopsisCommon(ECommandKeyScrape)"/>
        /// </summary>
        /// <param name="_in">基本的にEGitCommand.Valueを渡す</param>
        /// <returns></returns>
        public List<ECommandKeyScrape> ShapSynopsisCommonAll(List<ECommandKeyScrape> _in)
        {
            if (_in is null)
            {
                throw new ArgumentNullException(nameof(_in));
            }

            //引数には影響を与えないよう、以降は下記を使用する
            var c = new List<ECommandKeyScrape>(_in);

            //return
            var ret = new List<ECommandKeyScrape>();
            ECommandKeyScrape temp;
            foreach (var item in c)
            {
                temp = ShapSynopsisCommon(item);
                if (temp is null)
                {
                    //todo -> この例外はあとでShapSynopsisCommon(item);のほうで投げるようにする
                    throw new ObjectProcessFailureException<ECommandKeyScrape>("synopsis整形エラー", item);
                }

                ret.Add(temp);
            }

            return ret;
        }
    }
}
