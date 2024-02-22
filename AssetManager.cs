//MMP1 - AssetManager

using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

public class AssetManager
{
    ///<summary>
    ///6. AssetManager-class
    ///logic for Asset-Handling
    ///</summary>
    private static AssetManager instance;

    public static AssetManager Instance
    {
        get
        {
            if (instance == null)
                instance = new AssetManager();

            return instance;
        }
    }



    private AssetManager() { }
    public Dictionary<string, Texture> Textures = new Dictionary<string, Texture>();
    public Dictionary<string, SoundBuffer> SoundBuffers = new Dictionary<string, SoundBuffer>();
    public Dictionary<string, Music> Musics = new Dictionary<string, Music>();
    public Dictionary<string, Font> Fonts = new Dictionary<string, Font>();

    public void LoadShader(string vertexShaderPath, string geometryShaderPath, string fragmentShaderPath, string path)
    {

    }
    public void LoadTexture(string name, string filename)
    {
        Texture texture = new Texture(filename);
        Textures[name] = texture;
    }
    public void LoadSound(string name, string filename)
    {
        SoundBuffer sound = new SoundBuffer(filename);
        SoundBuffers[name] = sound;
    }
    public void LoadMusic(string name, string filename)
    {
        Music music = new Music(filename);
        Musics[name] = music;
    }
    public void LoadFont(string name, string filename)
    {
        Font font = new Font(filename);
        Fonts[name] = font;
    }

    public Texture GetTexture(string name)
    {
        if (Textures.ContainsKey(name))
        {
            return Textures[name];
        }
        else
        {
            throw new KeyNotFoundException($"Texture '{name}' not found in AssetManager");
        }
    }
    public SoundBuffer GetSoundBuffer(string name)
    {
        if (SoundBuffers.ContainsKey(name))
        {
            return SoundBuffers[name];
        }
        else
        {
            throw new KeyNotFoundException($"SoundBuffer '{name}' not found in AssetManager");
        }
    }
    public Music GetMusic(string name)
    {
        if (Musics.ContainsKey(name))
        {
            return Musics[name];
        }
        else
        {
            throw new KeyNotFoundException($"Music '{name}' not found in AssetManager");
        }
    }
    public Font GetFont(string name)
    {
        if (Fonts.ContainsKey(name))
        {
            return Fonts[name];
        }
        else
        {
            throw new KeyNotFoundException($"Font '{name}' not found in AssetManager");
        }
    }

    public void PlayMusic(string name)
    {
        if (Musics.ContainsKey(name))
        {
            Musics[name].Play();
            Musics[name].Volume = 40;
            Musics[name].Loop = true;
        }
        else
        {
            throw new KeyNotFoundException($"Music '{name}' not found in AssetManager");
        }
    }
    public void StopMusic(string name)
    {
        if (Musics.ContainsKey(name))
        {
            Musics[name].Stop();
        }
        else
        {
            throw new KeyNotFoundException($"Music '{name}' not found in AssetManager");
        }
    }
}