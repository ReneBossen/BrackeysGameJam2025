using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Brackeys.VN
{
    public class TextDisplay : MonoBehaviour
    {
        private TMP_Text _text;

        private float _timer;

        private int _index;

        private const float _displaySpeedRef = .01f;

        private string _toDisplay;
        public string ToDisplay
        {
            set
            {
                _index = 0;
                _timer = _displaySpeedRef;
                _text.text = string.Empty;
                if (value != null)
                {
                    _toDisplay = value.Replace("\r", ""); // Remove \r cause we don't care
                    SplitVertical();
                }
            }
            private get => _toDisplay;
        }

        public bool IsDisplayDone => _index == _toDisplay.Length;

        /// <summary>
        /// Makes sure the current text vertically fit in the box
        /// </summary>
        private void SplitVertical()
        {
            StringBuilder tmp = new();
            foreach (var word in _toDisplay.Split(' '))
            {
                var totalWidth = _text.GetPreferredValues($"{tmp} {word}");
                if (totalWidth.x > _text.rectTransform.rect.width)
                {
                    totalWidth = _text.GetPreferredValues($"{tmp}\n{word}");
                    if (totalWidth.y < _text.rectTransform.rect.height)
                    {
                        tmp.Append($"\n{word}");
                    }
                    else
                    {
                        break;
                    }
                }
                else if (totalWidth.y < _text.rectTransform.rect.height)
                {
                    tmp.Append($" {word}");
                }
                else
                {
                    break;
                }
            }
            var res = tmp.ToString()[1..];
            _toDisplay = res.TrimStart();
        }

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            if (_toDisplay != null)
            {
                if (_index < _toDisplay.Length)
                {
                    _timer -= Time.deltaTime;
                    if (_timer <= 0f)
                    {
                        _timer = _displaySpeedRef;
                        _text.text += _toDisplay[_index];
                        _index++;
                    }
                }
                else if (_timer < -2f)
                {
                    ToDisplay = null;
                }
            }
        }
    }
}