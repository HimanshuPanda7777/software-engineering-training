using System;
using System.Reflection.Metadata.Ecma335;

namespace StringManipulation;

public class ProcessString
{
    public string Manipulation(string str)
    {
        string[] words=str.Split(' ');
        if (words.Length%2 != 0)
        {
            for(int i = 0; i < words.Length; i++)
            {
                char[] charArray=words[i].ToCharArray();
                Array.Reverse(charArray);
                words[i]=new string(charArray);
            }
        }
        else
        {
            Array.Reverse(words);
        }

    return string.Join(" ",words);
    }
public bool UsernameValidate(string str)
    {
        bool val=true;
        if(!(str.Length>=5 && str.Length <=15))
        {
            throw new InvalidUsernameException("Invalid username");;
        
            
        }
        if (!(char.IsLetter(str[0])))
        {
            throw new InvalidUsernameException("Invalid username");;
            
        }
        for(int i = 0; i < str.Length; i++)
        {
            if(!(char.IsLetter(str[i]) || char.IsDigit(str[i]))){
                throw new InvalidUsernameException("Invalid username");;
                
            }
            
            if ((char.IsWhiteSpace(str[i])))
            {
                throw new InvalidUsernameException("Invalid username");;
            }
        }

        return val;
       
        }

        
    }
