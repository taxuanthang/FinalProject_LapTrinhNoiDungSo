#region Includes
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
#endregion

namespace TS.ColorPicker.Demo
{
    public class ColorPickerDemo : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        private List<MeshRenderer> _renderer = new List<MeshRenderer>();
        [SerializeField] private ColorPicker _colorPicker;
         public TextMeshProUGUI _textdisplay;

        public class LabubuPart
        {
            public string _name;
            public MeshRenderer[] _partRenderer;

            public LabubuPart(string _name, MeshRenderer[] _partRenderer)
            {
                this._name = _name;
                this._partRenderer = _partRenderer;
            }
            
        }
        int _labubuIndex = 0;

        public List<LabubuPart> labubuParts;

        private List<Color> _color = new List<Color>();
        private Ray _ray;
        private RaycastHit _hit;

        #endregion
        public void UpdateVariable()
        {
            _renderer.Clear();
            _color.Clear();
            for (int i = 0; i < labubuParts[_labubuIndex]._partRenderer.Length; i++)
            {
                _renderer.Add(labubuParts[_labubuIndex]._partRenderer[i]);
                Debug.Log(labubuParts[_labubuIndex]._partRenderer[i].material.color);
                _color.Add(labubuParts[_labubuIndex]._partRenderer[i].material.color);

            }
        }

        public void ChangeLabubuUp()
        {
            if (_labubuIndex == labubuParts.Count - 1)
            {
                _labubuIndex = 0;
            }
            else
            {
                _labubuIndex += 1;
            }
            UpdateVariable();
        }

        public void ChangeLabubuDown()
        {
            if (_labubuIndex == 0)
            {
                _labubuIndex = labubuParts.Count-1;
            }
            else
            {
                _labubuIndex -= 1;
            }
            UpdateVariable();

        }
        private void Start()
        {
            labubuParts = new List<LabubuPart>();
            labubuParts.Add(new LabubuPart("head", new MeshRenderer[] {
                this.transform.Find("headcover.001").GetComponent<MeshRenderer>(),
                this.transform.Find("earscover.001").GetComponent<MeshRenderer>(),
            }));
            labubuParts.Add(new LabubuPart("face", new MeshRenderer[] {
                this.transform.Find("head.001").GetComponent<MeshRenderer>()
            }));
            labubuParts.Add(new LabubuPart("body", new MeshRenderer[] {
                this.transform.Find("body.001").GetComponent<MeshRenderer>(),
                this.transform.Find("legs.001").GetComponent<MeshRenderer>(),
                this.transform.Find("arms.001").GetComponent<MeshRenderer>()

            }));

            UpdateVariable();

            _colorPicker.OnChanged.AddListener(ColorPicker_OnChanged);
            _colorPicker.OnSubmit.AddListener(ColorPicker_OnSubmit);
            _colorPicker.OnCancel.AddListener(ColorPicker_OnCancel);
            
        }
        private void Update()
        {

            _textdisplay.text = labubuParts[_labubuIndex]._name;

            //
            if (Input.GetMouseButtonUp(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit, 100))
                {
                    for (int i = 0; i < labubuParts[_labubuIndex]._partRenderer.Length; i++)
                    {
                        _colorPicker.Open(_color[i]);
                    }
                }
            }
        }

        private void ColorPicker_OnChanged(Color color)
        {
            for (int i = 0; i < labubuParts[_labubuIndex]._partRenderer.Length; i++)
            {
                _renderer[i].material.color = color;
            }
        }
        private void ColorPicker_OnSubmit(Color color)
        {
            for (int i = 0; i < labubuParts[_labubuIndex]._partRenderer.Length; i++)
            {
                _color[i] = color;
            }
        }
        private void ColorPicker_OnCancel()
        {
            for (int i = 0; i < labubuParts[_labubuIndex]._partRenderer.Length; i++)
            {
                _renderer[i].material.color = _color[i];
            }
        }
    }
}