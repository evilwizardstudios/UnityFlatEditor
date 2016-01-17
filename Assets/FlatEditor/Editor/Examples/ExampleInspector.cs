using FlatEditor.Input;
using FlatEditor.Popups;
using FlatEditor.Typography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Navigation = FlatEditor.Buttons.Navigation;
using PopupWindow = FlatEditor.Popups.FlatPopupWindow;

namespace FlatEditor.Example
{
    [CustomEditor(typeof (ExampleComponent))]
    public class ExampleInspector : Editor
    {
        private ExampleComponent _component;

        private Rect _windowRect = new Rect(100, 100, 200, 200);
        
        public override void OnInspectorGUI()
        {
            _component = target as ExampleComponent;
            if (_component == null) return;
            GUI.skin = FlatEditor.DefaultPanelSkin;

            GUILayout.BeginArea(_windowRect);
            _windowRect = GUILayout.Window(1, _windowRect, DoWindow, "Hi There");
            GUILayout.EndArea();

            _component.navSelection = Navigation.NavPills(new []{"Typography", "Input", "Buttons", "Dropdowns", "Tooltips", "Media Layout"}, new string[3], new string[3], _component.navSelection, Colors.Info);

            switch (_component.navSelection)
            {
                case 0:
                    TypographyExamples();
                    break;
                case 1:
                    InputExamples();
                    break;
                case 2:
                    ButtonExamples();
                    break;
                case 3:
                    DropdownExamples();
                    break;
                case 4:
                    TooltipExamples();
                    break;
                case 5 :
                    MediaLayoutExamples();
                    break;
            }


        }

        private void MediaLayoutExamples()
        {
        }

        private void TooltipExamples()
        {
            var rect = new Rect(200,200,200,200);
            GUI.DrawTexture(rect, Drawing.Pixel, ScaleMode.StretchToFill);

            Repaint();

        }

        void DoWindow(int unusedWindowID)
        {
            GUILayout.Button("Hi");
            GUI.DragWindow();
        }

        private void DropdownExamples()
        {
        }

        private void ButtonExamples()
        {
            Flat.Button("Here's a simple block button");
            GUILayout.BeginHorizontal();
            {
                Flat.Button("These can take color and size options, too", Style.Primary);
                Flat.Button("And, of course, glyphs", Style.Warning, "fa-link", null, Size.Small, false);
                Flat.Button("...and", Style.Danger, "fa-cube");
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            {
                Flat.Button("...badges", Style.Success, null, "New!", Size.Default, false);
                Flat.Button("Or both!", Style.Info, "fa-google-plus", "42");
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            {
                Flat.Button("Link-styled buttons", Style.Link);
                Flat.Button("can be used", Style.Link, "fa-bitbucket-square");
                Flat.Button("as well", Style.Link, "fa-comments-o", "Cool");
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                Flat.Button("fa-chrome");
                Flat.Button("fa-exclamation");
                Flat.Button("fa-plus-square-o");
                Flat.Button("fa-trophy");
                Flat.Button("fa-wifi");
                Flat.Button("fa-twitch");
                Flat.Button("fa-bomb");
                Flat.Button("fa-calendar-o");
                Flat.Button("fa-codepen");
                Flat.Button("fa-dot-circle-o");
                Flat.Button("fa-code");
                Flat.Button("fa-ge");
            }
            GUILayout.EndHorizontal();
        }

        private void InputExamples()
        {
            Flat.TextInput("", "", "", "");
            Flat.TextInput("check out these in-form icons -->", "front addons", "", "fa-instagram");
            Flat.TextInput("", "", "& back addons", "");
            _component.InputSingleLine = Forms.TextInputGroup(_component.InputSingleLine, "fa-twitter", "glyph'd up", "fa-check");
        }

        private void TypographyExamples()
        {
            Flat.Title("h1. Title heading", Heading.h1, "Secondary Text");
            Flat.Title("h2. Title heading", Heading.h2, "Secondary Text");
            Flat.Title("h3. Title heading", Heading.h3, "Secondary Text");
            Flat.Title("h4. Title heading", Heading.h4, "Secondary Text");
            Flat.Title("h5. Title heading", Heading.h5, "Secondary Text");
            Flat.Title("h6. Title heading", Heading.h6, "Secondary Text");

            Flat.Paragraph("Standard Paragraph. It is given a bottom margin of the editor's line height. Paragraphs always word-wrap. " +
                           "Nullam quis risus eget urna mollis ornare vel eu leo. Cum sociis natoque penatibus et magnis dis parturient " +
                           "montes, nascetur ridiculus mus. Nullam id dolor id nibh ultricies vehicula.");
            Flat.Paragraph("This paragraph is a lead style paragraph. Nullam quis risus eget urna mollis ornare vel eu leo. Cum sociis " +
                           "natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam id dolor id nibh ultricies " +
                           "vehicula.", true);

            Flat.Quote("this is a quote right here", "me, 2015", Style.Danger);
            Flat.Quote("here's a reversed quote", "still me, still 2015", Style.Primary, true);

        }
    }
}