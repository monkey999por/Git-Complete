namespace Git_Complete.src.props
{
    class DebugProps
    {
        /// <summary>
        /// instanceの作成時に、gitの公式から読み込むか
        /// </summary>
        public const bool IS_MAKE_ENTITY_FROM_GIT_HELP = true   ;

        /// <summary>
        /// デバッグモードを指定する。
        /// デバッグ時の挙動は主に作業用のコンソール出力、ファイル出力のみ
        /// アプリの本仕様には組み込まない。
        /// </summary>
        public const bool DEBUG_MODE = true;

    }
}
