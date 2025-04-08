namespace Blog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} baslikli makale basariyla eklenmistir";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} baslikli makale basariyla guncellenmistir";
            }
        }
    }
}
