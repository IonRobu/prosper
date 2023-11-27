using ProsperDaily.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Prosper.MVVM.Models;

public class TransactionCategory : TableData
{
	[Required]
	public string Name { get; set; }
}