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
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} baslikli makale basariyla silinmistir";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla eklenmistir";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla guncellenmistir";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adli kategori silinmistir";
            }

        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanici basariyla eklenmistir";
            }
            public static string Update(string userName)
            {
                return $"{userName} email adresli kullanici  basariyla guncellenmistir";
            }
            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanici silinmistir";
            }

        }
    }
}
