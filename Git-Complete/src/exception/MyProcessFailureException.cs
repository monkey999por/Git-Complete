using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.exception
{

    /// <summary>
    /// アプリケーション中で例外を投げたいときに、エラーが発生したオブジェクトを指定して例外を投げる
    /// 解析エラーがあったとき等で使用
    /// 
    /// ■利用方法
    /// throw new MyProcessFailureException<EGitCommand>("synopsisの解析エラー", eGitCommand);
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyProcessFailureException<T> : Exception
    {
        public string message;
        public T errorObject;

        public MyProcessFailureException() : base() { }

        public MyProcessFailureException(string message, T errorObject)
        {
            this.message = message;
            this.errorObject = errorObject;
        }
    }
}
