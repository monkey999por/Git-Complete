﻿using Git_Complete.src.exception;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Git_Complete.src.entity
{
    /// <summary>
    /// <see cref="ECommandKeyList{T}"/>のジェネリックで使用するためのクラス
    /// 本処理では上記以外の方法で直接使用することはない想定。
    ///（デバッグコード等での一時的な使用はあるが、正規の使い方ではない） 
    /// </summary>
    [Serializable]
    public class ECommandKey
    {
        //gitのコマンドを保持. primary key
#nullable enable
        [DataMember]
        public string? command;

        //各gitコマンドで使用できるSYNOPSISを保持する. 
        [DataMember]
        public List<string> synopsis = new List<string>();

        //各gitコマンドで使用できるオプションを保持する. 
        [DataMember]
        public List<string> options = new List<string>();

        //各gitコマンドで使用できるオプションの説明を保持する
        [DataMember]
        public List<string> optionsDescription = new List<string>();

        public ECommandKey() { }
        public ECommandKey(string command)
        {
            this.command = command;
        }

        /// <summary>
        /// Deep Copy
        /// </summary>
        /// <param name="_base">base object</param>
        public ECommandKey(ECommandKey _base)
        {
            if (_base.command is null)
            {
                throw new MyProcessFailureException<ECommandKey>(
                    "コマンドがnullです",
                    _base
                    );
            }

            //null対策
            var synopsis = _base.synopsis ?? new List<string>();
            var options = _base.options ?? new List<string>();
            var optionsDescription = _base.optionsDescription ?? new List<string>();

            this.command = _base.command;
            this.synopsis = new List<string>(synopsis);
            this.options = new List<string>(options);
            this.optionsDescription = new List<string>(optionsDescription);
        }
    }
}