using System;

public class clsSert
{
    public string noneInject(string input)
    {
        input = input.Replace("'", " ");
        input = input.Replace("NULL", " ");
        input = input.Replace("OR", " ");
        input = input.Replace("AND", " ");
        input = input.Replace("or", " ");
        input = input.Replace("oR", " ");
        input = input.Replace("Or", " ");
        input = input.Replace("And", " ");
        input = input.Replace("aNd", " ");
        input = input.Replace("anD", " ");
        input = input.Replace("ANd", " ");
        input = input.Replace("aND", " ");
        input = input.Replace("CR", " ");
        input = input.Replace("LF", " ");
        input = input.Replace("SELECT", " ");
        input = input.Replace("WHERE", " ");
        input = input.Replace("ORDER", " ");
        input = input.Replace("=", " ");
        return input;
    }
}