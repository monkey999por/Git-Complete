using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;

namespace Git_Complete.src.exception
{

    /// <summary>
    /// エラーが発生したオブジェクトを指定して例外を投げる.
    /// 本プロジェクトでは、<see cref="ECommandKeyList{T}.Value"/>をループでの解析処理がメインとなる
    /// <see cref="ECommandKeyList{T}.Value"/>は基本的に<see cref="CommonProps.ALL_COMMAND"/>をキーとした
    /// <see cref="ECommandKey"/>を継承したクラスのリストとなる。
    /// <see cref="ECommandKeyList{T}.Value"/>のループ処理中に業務例外を起こす際、どのコマンドで処理がエラーとなったのか
    /// を明確にすることを目的として本例外を発生させる。
    /// 
    /// ■利用方法
    /// <code>
    /// throw new <see cref="ObjectProcessFailureException{T}"/>("synopsisの解析エラー", obj); 
    /// </code>
    /// </summary>
    /// <typeparam name="T"><see cref="ECommandKey"/>を継承したクラス</typeparam>
    class ObjectProcessFailureException<T> : Exception
    {
        public string message;
        public T errorObject;

        public ObjectProcessFailureException() : base() { }

        public ObjectProcessFailureException(string message, T errorObject)
        {
            this.message = message;
            this.errorObject = errorObject;
        }
    }
}
