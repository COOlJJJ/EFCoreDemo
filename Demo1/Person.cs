using System.ComponentModel.DataAnnotations;

namespace Demo1
{
    /// <summary>
    /// Data Annotation配置
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Tips:自增作为物理主键 Guid作为逻辑主键
        /// </summary>
        public long Id { get; set; }
        [Required]
        public int Age { get; set; }
        public string Name { get; set; }
        
        public string BirthPlace { get; set; }
    }
}