namespace EFCoreDemo3
{
    public class Comment
    {
        public long Id { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// 引用导航属性
        /// </summary>
        public Article Article { get; set; }
        /// <summary>
        /// 外键
        /// </summary>
        public long ArticleId { get; set; }
    }
}