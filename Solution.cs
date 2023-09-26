using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string operation = Console.ReadLine();
        int pseudoRandomNumber = int.Parse(Console.ReadLine());
        Rot[] rotors = new Rot[3];
        rotors[0] = new Rot(Console.ReadLine(), pseudoRandomNumber, 1);
        for (int i = 1; i < 3; i++)
        {
            rotors[i] = new Rot(Console.ReadLine());
        }
        string message = Console.ReadLine();

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        if(operation == "ENCODE")
        {
            Console.WriteLine(Encode(message, rotors));
        }
        else if(operation == "DECODE")
        {
            Console.WriteLine(Decode(message, rotors.Reverse().ToArray()));
        }
        
    }

    static string Encode(string txt, Rot[] rotors)
    {
        foreach(var c in rotors)
        {
            txt = c.Encode(txt);
        }

        return txt;
    }
    static string Decode(string txt, Rot[] rotors)
    {
        foreach(var c in rotors)
        {
            txt = c.Decode(txt);
        }

        return txt;
    }
}

class Rot
{
    string rotor;
    int N;
    int inc;

    public Rot(string s)
    {
        rotor = s;
        N = 0;
        inc = 0;
    }
    public Rot(string s, int a, int b)
    {
        rotor = s;
        N = a;
        inc = b;
    }

    public string Encode(string txt)
    {
        var n = N;
        var returned = "";
        foreach(var c in txt)
        {
            returned += ((char)(rotor[((int)c-(int)'A'+N)%26]));
            N += inc;
        }
        N = n;
        return returned;
    }

    public string Decode(string txt)
    {
        var returned = "";
        var n = N;
        foreach(var c in txt)
        {
            returned += (char)((rotor.IndexOf(c) - n%26 + 26 + N - (N)%26)%26 + (int)'A');
            n += inc;            
        }
        return returned;
    }
}
