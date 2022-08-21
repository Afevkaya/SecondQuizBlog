﻿using System.ComponentModel.DataAnnotations;

namespace SecondQuizBlog.Models
{
    public class CreatePostViewModel
    {
        [StringLength(20,ErrorMessage = "Başlık alanı en fazla 20 karakter olmalıdır.")]
        [Required(ErrorMessage = "Başlık alanı doldurmak zorunludur")]
        public string Title { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 50, ErrorMessage = "Açıklama 50 karakterden fazla olmalıdır.")]
        [Required(ErrorMessage = "Açıklama alanı doldurmak zorunludur")]
        public string ContentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Fotoğraf seçmek doldurmak zorunludur")]
        public string ImageUrl { get; set; }
        
        public int CategoryId { get; set; }

    }
}
