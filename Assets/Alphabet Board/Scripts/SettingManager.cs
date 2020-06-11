using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour
{
	public Toggle fullScreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Slider musicVolumeSlider;
	public AudioSource musicSource;
	public Button applyButton;

	public Resolution[] resolutions;
	public GameSettings gameSettings;

	void OnEnable()
	{
		gameSettings = new GameSettings();

		fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreentoggle(); });
		resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
		textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
		musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
		OnApplyButtonClick();
		//applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
		
		resolutions = Screen.resolutions;

		foreach (Resolution resolution in resolutions)
		{
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}

		LoadSettings();
	}

	public void OnFullScreentoggle()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullScreenToggle.isOn;
	}

	public void OnResolutionChange()
	{
		Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionIndex = resolutionDropdown.value;
	}

	public void OnTextureQualityChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}

	public void OnMusicVolumeChange()
	{
		musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
	}

	public void OnApplyButtonClick()
	{
		SaveSettings();
	}

	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
	}

	public void LoadSettings()
	{
		gameSettings = JsonUtility.FromJson<GameSettings>(Application.persistentDataPath + "/gamesettings.json");

		musicVolumeSlider.value = gameSettings.musicVolume;
		textureQualityDropdown.value = gameSettings.textureQuality;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullScreenToggle.isOn = gameSettings.fullscreen;
		Screen.fullScreen = gameSettings.fullscreen;

		resolutionDropdown.RefreshShownValue();
	}

	public void onMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
