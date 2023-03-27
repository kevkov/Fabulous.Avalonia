namespace Gallery

open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ThemeAware =
    type Model =
        { CurrentTheme: ThemeVariant
          ScopeTheme: ThemeVariant
          Items: ThemeVariant list
          Text: string
          Text2: string }

    type Msg =
        | SetTheme of ThemeVariant
        | OnSelectionChanged of SelectionChangedEventArgs
        | TextChanged of string
        | Text2Changed of string
        | DoNothing
        | ThemeVariantChanged of ThemeVariant

    let init () =
        { CurrentTheme = Avalonia.Application.Current.ActualThemeVariant
          ScopeTheme = ThemeVariant.Default
          Items =
            [ ThemeVariant.Default
              ThemeVariant.Dark
              ThemeVariant.Light
              ThemeVariant("Pink", ThemeVariant.Light) ]
          Text = ""
          Text2 = "" }

    let update msg model =
        match msg with
        | SetTheme variant ->
            Avalonia.Application.Current.RequestedThemeVariant <- variant
            { model with CurrentTheme = variant }

        | OnSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let index = control.SelectedIndex
            let variant = model.Items.[index]

            { model with ScopeTheme = variant }

        | TextChanged text -> { model with Text = text }

        | Text2Changed text -> { model with Text2 = text }

        | DoNothing -> model

        | ThemeVariantChanged themeVariant -> { model with ScopeTheme = themeVariant }

    let view model =
        VStack(spacing = 15.) {
            TextBlock($"Current theme is: {model.CurrentTheme.ToString()}")
            TextBlock($"Actual theme is: {Avalonia.Application.Current.ActualThemeVariant.ToString()}")
            TextBlock($"ScopedTheme is: {model.ScopeTheme.ToString()}")

            HStack() {
                Button("Set default theme", SetTheme ThemeVariant.Default)
                Button("Set light theme", SetTheme ThemeVariant.Light)
                Button("Set dark theme", SetTheme ThemeVariant.Dark)
            }

            TextBlock("I'm a text that is theme aware")
                .foreground(SolidColorBrush(ThemeAware.With(Colors.Red, Colors.Green)))

            ThemeVariantScope(
                model.ScopeTheme,
                Border(
                    Grid(coldefs = [ Pixel(150.); Pixel(150.) ], rowdefs = [ Auto; Pixel(4.); Auto; Pixel(4.); Auto; Pixel(4.); Auto ]) {
                        (ComboBox() {
                            for item in model.Items do
                                ComboBoxItem(
                                    TextBlock(item.ToString())
                                        .foreground(
                                            SolidColorBrush(
                                                if model.ScopeTheme = ThemeVariant.Light then
                                                    Colors.Red
                                                else
                                                    Colors.Green
                                            )
                                        )
                                )
                        })
                            .gridColumn(0)
                            .gridRow(0)
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                            .selectedIndex(0)
                            .onSelectionChanged(OnSelectionChanged)

                        TextBlock("Username:")
                            .gridColumn(0)
                            .gridRow(2)
                            .verticalAlignment(VerticalAlignment.Center)

                        TextBlock("Password:")
                            .gridColumn(0)
                            .gridRow(4)
                            .verticalAlignment(VerticalAlignment.Center)

                        TextBox(model.Text, TextChanged)
                            .watermark("Input here")
                            .gridColumn(1)
                            .gridRow(2)
                            .horizontalAlignment(HorizontalAlignment.Stretch)

                        TextBox(model.Text2, Text2Changed)
                            .watermark("Input here")
                            .gridColumn(1)
                            .gridRow(4)
                            .horizontalAlignment(HorizontalAlignment.Stretch)

                        Button("Login", DoNothing)
                            .gridColumn(1)
                            .gridRow(6)
                            .horizontalAlignment(HorizontalAlignment.Stretch)
                    }
                )
                    .verticalAlignment(VerticalAlignment.Top)
                    .horizontalAlignment(HorizontalAlignment.Left)
                    .padding(4.)
                    .cornerRadius(4.)
                    .background(SolidColorBrush(Colors.Black))
            )
        }

    let sample =
        { Name = "ThemeAware"
          Description = "ThemeAware is a custom modifier that changes its appearance based on the current theme."
          Program = Helper.createProgram init update view }
