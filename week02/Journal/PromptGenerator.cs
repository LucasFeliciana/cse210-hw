
using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "What was the best part of your day?",
        "Who was the most interesting person you talked to today?",
        "What is something new you learned today?",
        "What made you feel happy today?",
        "What is something you would like to improve tomorrow?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}
