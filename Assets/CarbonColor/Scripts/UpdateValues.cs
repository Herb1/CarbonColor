using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateValues : MonoBehaviour {

    public string RedName = "R: ";
    public string GreenName = "G: ";
    public string BlueName = "B: ";
    public string AlphaName = "A: ";

    public Text RedText;
    public Slider RedSlider;

    public Text GreenText;
    public Slider GreenSlider;

    public Text BlueText;
    public Slider BlueSlider;

    public Text AlphaText;
    public Slider AlphaSlider;

    public InputField HexField;

    public CarbonColorChooser CarbonColorChooser;

    public Image PreviewImage;

    public void SetValues(Color color)
    {
        RedText.text = RedName + (int)(color.r * 255);
        RedSlider.value = (int)(color.r * 255);

        GreenText.text = GreenName + (int)(color.g * 255);
        GreenSlider.value = (int)(color.g * 255);

        BlueText.text = BlueName + (int)(color.b * 255);
        BlueSlider.value = (int)(color.b * 255);

        color.a = (AlphaSlider.value / 255);

        PreviewImage.color = color;

        HexField.text = ColorUtility.ToHtmlStringRGBA(color);
    }
    public void UpdateRedSlider(Slider slider)
    {
        RedText.text = RedName + (int)(slider.value);
        UpdateColorFromValues();
    }

    public void UpdateGreenSlider(Slider slider)
    {
        GreenText.text = GreenName + (int)(slider.value);
        UpdateColorFromValues();
    }

    public void UpdateBlueSlider(Slider slider)
    {
        BlueText.text = BlueName + (int)(slider.value);
        UpdateColorFromValues();
    }

    public void UpdateAlphaSlider(Slider slider)
    {
        AlphaText.text = AlphaName + (int)(slider.value);
        UpdateColorFromValues();
    }

    public void UpdateInputField(InputField field)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString("#" + field.text, out color)) {

            RedText.text = RedName + (int)(color.r * 255);
            RedSlider.value = (int)(color.r * 255);

            GreenText.text = GreenName + (int)(color.g * 255);
            GreenSlider.value = (int)(color.g * 255);

            BlueText.text = BlueName + (int)(color.b * 255);
            BlueSlider.value = (int)(color.b * 255);

            AlphaText.text = AlphaName + (int)(color.a * 255);
            AlphaSlider.value = (int)(color.a * 255);

            UpdateColorFromValues();
        }

    }


    private void UpdateColorFromValues()
    {
        Color newColor = new Color(RedSlider.value / 255, GreenSlider.value / 255, BlueSlider.value / 255, AlphaSlider.value / 255);

        HexField.text = ColorUtility.ToHtmlStringRGBA(newColor);

        float h =0, s = 0, v = 0;

        Color.RGBToHSV(newColor, out h, out s, out v);
        CarbonColorChooser.UpdateColorFromValues(((360 * h) - 180), newColor);
    }
}
