using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Темы
{
    public int КодПреподавателя { get; set; }

    public string ТемаДипломнойРаботы { get; set; } = null!;

    public virtual Преподаватели? Преподаватели { get; set; }

    public virtual ВыбранныеТемы ТемаДипломнойРаботыNavigation { get; set; } = null!;
}
