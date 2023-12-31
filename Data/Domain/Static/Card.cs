﻿using Methodic.Data.Domain.Base;

namespace Data.Domain.Static;

public class Card : StaticEntity<int>
{
	public string Number { get; set; }

	public string Description {  get; set; }
}