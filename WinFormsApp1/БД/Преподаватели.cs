using System;
using System.Collections.Generic;

namespace WinFormsApp1;

public partial class Преподаватели
{
    public int КодПреподавателя { get; set; }

    public string Фио { get; set; } = null!;

    public string? Степень { get; set; }

    public string? Звание { get; set; }

    public string Кафедра { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public string? Email { get; set; }

    public virtual Темы КодПреподавателяNavigation { get; set; } = null!;
}
