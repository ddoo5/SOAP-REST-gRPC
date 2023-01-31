using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LibService.View.Models
{
	public enum SearchType
	{
		[Display(Name ="Заголовок")]
		Title,
        [Display(Name = "Автор")]
        Author,
        [Display(Name = "Категория")]
        Category
	}
}

