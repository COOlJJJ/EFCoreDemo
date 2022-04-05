using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemo3
{
    class Program
    {
        /// <summary>
        /// 
        /// 一对多 HasOne().WithMany()
        /// 一对一 HasOne().WithOne()
        /// 多对多 HasMany().WithMany() 这种情况可以通过中间对象实现更好 杨旭那边有讲过可看  配置多对多 ，就是两个一对多 参考Post和Tag
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (MyDbContext myDbContext = new MyDbContext())
            {

                #region 一对多
                //一对多数据添加
                Article article = new Article { Message = "Nice", Title = "ArticleB" };
                Comment commentA = new Comment { Message = "CommentA" };
                Comment commentB = new Comment { Message = "CommentB" };
                Comment commentC = new Comment { Message = "CommentC" };
                List<Comment> comments = new List<Comment>
                {
                    commentA,
                    commentB,
                    commentC
                };
                article.comments = comments;
                myDbContext.Articles.Add(article);
                myDbContext.SaveChanges();


                //查一个文章
                //var comment = myDbContext.Articles.Where(x => x.Id == 5).FirstOrDefault();
                //Console.WriteLine(comment);

                //根据评论关联查一个文章
                var comment = myDbContext.Comments.Where(x => x.Id == 6).Include(x => x.Article).FirstOrDefault();
                Console.WriteLine(comment.Article.Title);

                //一对多查询 查谋篇文章以及下面的评论
                //可以使用 Include 方法来指定要包含在查询结果中的关联数据
                //可以在单个查询中包含多个关系的关联数据。 比如文章下面有多个评论 多个文章修改日志
                //不需要修改的东西可以不追踪查询
                Article commentID1 = (Article)myDbContext.Articles.AsNoTracking().Where(x => x.Id == 1).Include(article => article.comments).FirstOrDefault();
                foreach (var item in commentID1.comments)
                {
                    Console.WriteLine(item.Message);
                }
                #endregion

                #region 多对多

                //添加数据 两个一对多 分别添加 post实体 和中间表关系 和tag实体即可
                Post post = new Post { Title = "文章B", Content = "我是测试B" };
                Tag tagA = new Tag { Id = "1", Name = "A标签" };
                Tag tagB = new Tag { Id = "2", Name = "B标签" };
                PostTag postTag1 = new PostTag { TagId = "1" };
                PostTag postTag2 = new PostTag { TagId = "2" };
                List<PostTag> postTags = new List<PostTag>
                {
                   postTag1,
                   postTag2
                };
                post.PostTags = postTags;
                myDbContext.Posts.Add(post);
                myDbContext.Tags.Add(tagA);
                myDbContext.Tags.Add(tagB);
                myDbContext.SaveChanges();

                //多对多查询
                var query = from posttag in myDbContext.PostTag
                            join tag in myDbContext.Tags
                                on posttag.TagId equals tag.Id
                            where posttag.PostId.Equals(1)
                            select new { tag.Name };

                Console.WriteLine(query.ToList());
                foreach (var item in query.ToList())
                {
                    Console.WriteLine(item.Name);
                }

                #endregion
            }


        }
    }
}
