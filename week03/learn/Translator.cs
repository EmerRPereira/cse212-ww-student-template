/*public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        Console.WriteLine(englishToGerman.Translate("Car")); // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// For example, in a english to german dictionary:
    /// 
    /// my_translator.AddWord("book","buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    /// <returns>fixed array of divisors</returns>
    public void AddWord(string fromWord, string toWord)
    {
        // ADD YOUR CODE HERE
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        // ADD YOUR CODE HERE
        return "";
    }
}



using System;
using System.Collections.Generic;

public class Translator
{
    private Dictionary<string, string> _translations = new Dictionary<string, string>();
    
    /// <summary>
    /// Adiciona uma tradução de palavra
    /// </summary>
    /// <param name="word">Palavra no idioma original (inglês)</param>
    /// <param name="translation">Tradução para o idioma alvo (alemão)</param>
    public void AddWord(string word, string translation)
    {
        // Verifica se a palavra já existe no dicionário
        if (_translations.ContainsKey(word))
        {
            Console.WriteLine($"Aviso: A palavra '{word}' já possui uma tradução. Substituindo de '{_translations[word]}' para '{translation}'.");
            _translations[word] = translation;
        }
        else
        {
            // Adiciona a nova tradução
            _translations.Add(word, translation);
            Console.WriteLine($"Tradução adicionada: '{word}' -> '{translation}'");
        }
    }
    
    /// <summary>
    /// Traduz uma palavra do idioma original para o idioma alvo
    /// </summary>
    /// <param name="word">Palavra a ser traduzida</param>
    /// <returns>Tradução da palavra ou "???" se não encontrada</returns>
    public string Translate(string word)
    {
        // Tenta encontrar a tradução no dicionário
        if (_translations.TryGetValue(word, out string? translation))
        {
            return translation;
        }
        
        // Se não encontrar, retorna "???"
        return "???";
    }
    
    /// <summary>
    /// Retorna o número de traduções no dicionário
    /// </summary>
    public int Count => _translations.Count;
    
    /// <summary>
    /// Limpa todas as traduções
    /// </summary>
    public void Clear()
    {
        _translations.Clear();
        Console.WriteLine("Todas as traduções foram removidas.");
    }
    
    /// <summary>
    /// Verifica se uma palavra existe no dicionário
    /// </summary>
    public bool HasWord(string word)
    {
        return _translations.ContainsKey(word);
    }
}

*/

using System;
using System.Collections.Generic;

public class Translator
{
    private Dictionary<string, string> _translations = new Dictionary<string, string>();
    
    public void AddWord(string word, string translation)
    {
        if (_translations.ContainsKey(word))
        {
            Console.WriteLine($"Aviso: '{word}' já existe. Atualizando de '{_translations[word]}' para '{translation}'");
            _translations[word] = translation;
        }
        else
        {
            _translations.Add(word, translation);
            Console.WriteLine($"Adicionado: '{word}' -> '{translation}'");
        }
    }
    
    public string Translate(string word)
    {
        // Removido o '?' para evitar o aviso CS8632
        if (_translations.TryGetValue(word, out string translation))
        {
            return translation;
        }
        return "???";
    }
    
    public int Count
    {
        get { return _translations.Count; }
    }
    
    public void Clear()
    {
        _translations.Clear();
        Console.WriteLine("Todas as traduções foram removidas.");
    }
    public static void Run()
    {
        Console.WriteLine("\n=== Tradutor Inglês-Alemão ===");
        
        var tradutor = new Translator();
        
        // Adicionar traduções
        tradutor.AddWord("hello", "hallo");
        tradutor.AddWord("goodbye", "auf Wiedersehen");
        tradutor.AddWord("thank you", "danke");
        tradutor.AddWord("yes", "ja");
        tradutor.AddWord("no", "nein");
        
        Console.WriteLine($"\nTotal de traduções: {tradutor.Count}\n");
        
        // Testar traduções
        Console.WriteLine("Testando traduções:");
        Console.WriteLine($"hello -> {tradutor.Translate("hello")}");
        Console.WriteLine($"goodbye -> {tradutor.Translate("goodbye")}");
        Console.WriteLine($"thank you -> {tradutor.Translate("thank you")}");
        Console.WriteLine($"yes -> {tradutor.Translate("yes")}");
        Console.WriteLine($"no -> {tradutor.Translate("no")}");
        Console.WriteLine($"computer -> {tradutor.Translate("computer")}"); // Deve mostrar "???"
    }
}