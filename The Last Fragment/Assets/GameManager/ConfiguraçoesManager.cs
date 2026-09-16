using UnityEngine;
using UnityEngine.UI;

public class ConfiguracoesManager : MonoBehaviour
{
    public Slider sliderVolume;

    private void Start()
    {
        // Se o Slider não estiver configurado no Inspector,
        // procura automaticamente pelo objeto
        if (sliderVolume == null)
        {
            GameObject objetoSlider = GameObject.Find("SliderVolume");

            if (objetoSlider != null)
            {
                sliderVolume = objetoSlider.GetComponent<Slider>();
            }
        }

        // Verifica se encontrou o Slider
        if (sliderVolume == null)
        {
            Debug.LogError("ERRO: Não foi encontrado o SliderVolume!");
            return;
        }

        float volumeSalvo = PlayerPrefs.GetFloat("Volume", 1f);

        sliderVolume.value = volumeSalvo;
        AudioListener.volume = volumeSalvo;
    }

    public void AlterarVolume(float volume)
    {
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void Voltar()
    {
        GameManager.Instance.IrParaMenu();
    }

    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}