using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Темы
{
    public int КодПреподавателя { get; set; }

    public string ТемаДипломнойРаботы { get; set; } = null!;

    public virtual Преподаватели КодПреподавателяNavigation { get; set; } = null!;

    public virtual ВыбранныеТемы ТемаДипломнойРаботыNavigation { get; set; } = null!;
}
