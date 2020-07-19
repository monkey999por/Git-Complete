using Git_Complete.src.function.common;
using Git_Complete.src.entity;
using Git_Complete.src.props;
using Git_Complete.src.entity.temp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Git_Complete.src.exception;

namespace Git_Complete.src.parser
{
    class GitEntityParser
    {
        /// <summary>
        /// sinopsisの共通解析。解析のルールは下記を参照。（基本的にLinuxのmanページのsynopsisと同じ形式。斜め文字や太字でのルールはない）
        /// ※synopsisに共通的なルールはないため、いったんGitのsynopsisをベースに解析する。
        /// <see cref="https://qiita.com/mather314/items/a53da94359d54443bcdc"/>
        /// </summary>
        /// <param name="_in"></param>
        /// <returns></returns>
        private EGitCommand ShapSynopsisCommon(EGitCommand _in)
        {
            return _in;
        }

        /// <summary>
        /// sinopsisの共通解析呼び出しサブルーチン。
        /// 利用側では主にリストをメインで処理を行うので、下記を定義。
        /// 引数は直接使用しない（引数に対して変更を行わない）
        /// 
        /// <see cref="ShapSynopsisCommon(EGitCommand)"/>
        /// </summary>
        /// <param name="_in">基本的にEGitCommand.Valueを渡す</param>
        /// <returns></returns>
        public List<EGitCommand> ShapSynopsisCommonAll(List<EGitCommand> _in) 
        {
            if (_in is null)
            {
                throw new ArgumentNullException(nameof(_in));
            }

            //引数には影響を与えないよう、以降は下記を使用する
            var c = new List<EGitCommand>(_in);

            //return
            var ret = new List<EGitCommand>();
            EGitCommand temp;
            foreach (var item in c)
            {   
                temp = ShapSynopsisCommon(item);
                if (temp is null) 
                {
                    //todo -> この例外はあとでShapSynopsisCommon(item);のほうで投げるようにする
                    throw new MyProcessFailureException<EGitCommand>("synopsis解析エラー", item);
                }

                ret.Add(temp);
            }

            return ret;
        }
    }
}
