1. Write a C# program that reads a list of integers from the user and throws an exception if any numbers are duplicates.
 

 try
{               
    List<int> numbers = new List<int>();
    
    Console.WriteLine("Enter integers one by one :");
    
  
    while (true)
    
    {
    
        int input = int.Parse(Console.ReadLine());
        
        if (numbers.Contains(input))
        
        {
        
            throw new Exception($"Duplicate number found: {input}");
            
        }
        
        numbers.Add(input);
        
    } 
    
}

catch (Exception ex)

{

    Console.WriteLine(ex.Message);
    
}

finally             //دي هتتنفذ سواء في اكسبشن او لا 

{

    Console.WriteLine("mission compelete");
    
}


3. Write a C# program to create a method that takes a string as input and throws an exception if the string does not contain vowels.

 try
 
 {
 
     Console.Write("Enter a string : ");
     
     string input = Console.ReadLine(); 
     
     string lowerInput = input.ToLower();  
     
     char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
     

     bool hasVowel = false;
     
    
     for (int i = 0; i < lowerInput.Length; i++)
     
     {
     
         for (int j = 0; j < vowels.Length; j++)
         
         {
         
             if (lowerInput[i] == vowels[j])
             
             {
             
                 hasVowel = true;
                 
                 break; 
                 
             }
         }
         
         if (hasVowel) break;
         
     }
     
     if (!hasVowel)
     
     {
     
         throw new Exception("The string does not contain any vowels!");      // او لا catch هيطبعلي الاكسبشن سواء عملت throw طلاما قولت 
         
    
     }

     Console.WriteLine("The string contains vowels.");
     
 }
 
  finally             //  لازم اعمل كاتش او فاينالي بعد التراي   
  
 {  
 
     Console.WriteLine("mission compelete");
     
 }
 
 
