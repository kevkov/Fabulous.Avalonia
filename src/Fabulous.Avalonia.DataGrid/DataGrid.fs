namespace Fabulous.Avalonia

open System
open System.Collections
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Media
open Avalonia.Media.Immutable
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabDataGrid =
    inherit IFabTemplatedControl

module DataGrid =
    let WidgetKey = Widgets.register<DataGrid>()

    let IsReadOnly =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.IsReadOnlyProperty

    let AutoGeneratedColumns =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.AutoGenerateColumnsProperty

    let CanUserReorderColumns =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.CanUserReorderColumnsProperty

    let CanUserResizeColumns =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.CanUserResizeColumnsProperty

    let CanUserSortColumns =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.CanUserSortColumnsProperty

    let GridLinesVisibility =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.GridLinesVisibilityProperty

    let ColumnHeaderHeight =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.ColumnHeaderHeightProperty

    let ColumnWidth =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.ColumnWidthProperty

    let RowTheme =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.RowThemeProperty

    let CellTheme =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.CellThemeProperty

    let ColumnHeaderTheme =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.ColumnHeaderThemeProperty

    let RowGroupTheme =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.RowGroupThemeProperty

    let FrozenColumnCount =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.FrozenColumnCountProperty

    let HeadersVisibility =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.HeadersVisibilityProperty

    let HorizontalGridLinesBrush =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.HorizontalGridLinesBrushProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.HorizontalScrollBarVisibilityProperty

    let AreRowGroupHeadersFrozen =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.AreRowGroupHeadersFrozenProperty

    let MaxColumnWidth =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.MaxColumnWidthProperty

    let MinColumnWidth =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.MinColumnWidthProperty

    let RowBackground =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.RowBackgroundProperty

    let RowHeight =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.RowHeightProperty

    let RowHeaderWidth =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.RowHeaderWidthProperty

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.SelectionModeProperty

    let VerticalGridLinesBrush =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.VerticalGridLinesBrushProperty

    let VerticalScrollBarVisibility =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.VerticalScrollBarVisibilityProperty

    let SelectedIndex =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.SelectedIndexProperty

    let ClipboardCopyMode =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.ClipboardCopyModeProperty

    let AreRowDetailsFrozen =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.AreRowDetailsFrozenProperty

    let RowDetailsVisibilityMode =
        Attributes.defineAvaloniaPropertyWithEquality DataGrid.RowDetailsVisibilityModeProperty

    let Items =
        Attributes.definePropertyWithGetSet
            "DataGrid_Items"
            (fun target ->
                let target = target :?> DataGrid
                target.ItemsSource)
            (fun target value ->
                let target = target :?> DataGrid
                target.ItemsSource <- value)

    let Columns =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "DataGrid_Columns" (fun target -> (target :?> DataGrid).Columns :> IList)

    let HorizontalScroll =
        Attributes.defineEvent "DataGrid_HorizontalScroll" (fun target -> (target :?> DataGrid).HorizontalScroll)

    let VerticalScroll =
        Attributes.defineEvent "DataGrid_VerticalScroll" (fun target -> (target :?> DataGrid).VerticalScroll)

    let AutoGeneratingColumn =
        Attributes.defineEvent "DataGrid_AutoGeneratingColumn" (fun target -> (target :?> DataGrid).AutoGeneratingColumn)

    let BeginningEdit =
        Attributes.defineEvent "DataGrid_BeginningEdit" (fun target -> (target :?> DataGrid).BeginningEdit)

    let CellEditEnded =
        Attributes.defineEvent "DataGrid_CellEditEnded" (fun target -> (target :?> DataGrid).CellEditEnded)

    let CellEditEnding =
        Attributes.defineEvent "DataGrid_CellEditEnding" (fun target -> (target :?> DataGrid).CellEditEnding)

    let CellPointerPressed =
        Attributes.defineEvent "DataGrid_CellPointerPressed" (fun target -> (target :?> DataGrid).CellPointerPressed)

    let ColumnDisplayIndexChanged =
        Attributes.defineEvent "DataGrid_ColumnDisplayIndexChanged" (fun target -> (target :?> DataGrid).ColumnDisplayIndexChanged)

    let ColumnReordered =
        Attributes.defineEvent "DataGrid_ColumnReordered" (fun target -> (target :?> DataGrid).ColumnReordered)

    let ColumnReordering =
        Attributes.defineEvent "DataGrid_ColumnReordering" (fun target -> (target :?> DataGrid).ColumnReordering)

    let CurrentCellChanged =
        Attributes.defineEvent "DataGrid_CurrentCellChanged" (fun target -> (target :?> DataGrid).CurrentCellChanged)

    let LoadingRow =
        Attributes.defineEvent "DataGrid_LoadingRow" (fun target -> (target :?> DataGrid).LoadingRow)

    let PreparingCellForEdit =
        Attributes.defineEvent "DataGrid_PreparingCellForEdit" (fun target -> (target :?> DataGrid).PreparingCellForEdit)

    let RowEditEnded =
        Attributes.defineEvent "DataGrid_RowEditEnded" (fun target -> (target :?> DataGrid).RowEditEnded)

    let RowEditEnding =
        Attributes.defineEvent "DataGrid_RowEditEnding" (fun target -> (target :?> DataGrid).RowEditEnding)

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "DataGrid_SelectionChanged" (fun target -> (target :?> DataGrid).SelectionChanged)

    let Sorting =
        Attributes.defineEvent "DataGrid_Sorting" (fun target -> (target :?> DataGrid).Sorting)

    let UnloadingRow =
        Attributes.defineEvent "DataGrid_UnloadingRow" (fun target -> (target :?> DataGrid).UnloadingRow)

    let LoadingRowDetails =
        Attributes.defineEvent "DataGrid_LoadingRowDetails" (fun target -> (target :?> DataGrid).LoadingRowDetails)

    let RowDetailsVisibilityChanged =
        Attributes.defineEvent "DataGrid_RowDetailsVisibilityChanged" (fun target -> (target :?> DataGrid).RowDetailsVisibilityChanged)

    let UnloadingRowDetails =
        Attributes.defineEvent "DataGrid_UnloadingRowDetails" (fun target -> (target :?> DataGrid).UnloadingRowDetails)

[<AutoOpen>]
module DataGridBuilders =
    type Fabulous.Avalonia.View with

        static member DataGrid(items: #IEnumerable) =
            CollectionBuilder<'msg, IFabDataGrid, #IFabDataGridColumn>(DataGrid.WidgetKey, DataGrid.Columns, DataGrid.Items.WithValue(items))

        static member AutoGeneratedDataGrid(items: #IEnumerable) =
            WidgetBuilder<'msg, IFabDataGrid>(DataGrid.WidgetKey, DataGrid.Items.WithValue(items), DataGrid.AutoGeneratedColumns.WithValue(true))

[<Extension>]
type DataGridModifiers =
    /// <summary>Link a ViewRef to access the direct TabControl control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDataGrid>, value: ViewRef<DataGrid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Sets the IsReadOnly property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsReadOnly value.</param>
    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.IsReadOnly.WithValue(value))

    /// <summary>Sets the AutoGenerateColumns property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoGenerateColumns value.</param>
    [<Extension>]
    static member inline autoGenerateColumns(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.AutoGeneratedColumns.WithValue(value))

    /// <summary>Sets the CanUserReorderColumns property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CanUserReorderColumns value.</param>
    [<Extension>]
    static member inline canUserReorderColumns(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.CanUserReorderColumns.WithValue(value))

    /// <summary>Sets the CanUserResizeColumns property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CanUserResizeColumns value.</param>
    [<Extension>]
    static member inline canUserResizeColumns(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.CanUserResizeColumns.WithValue(value))

    /// <summary>Sets the CanUserSortColumns property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CanUserSortColumns value.</param>
    [<Extension>]
    static member inline canUserSortColumns(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.CanUserSortColumns.WithValue(value))

    /// <summary>Sets the GridLinesVisibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The GridLinesVisibility value.</param>
    [<Extension>]
    static member inline gridLinesVisibility(this: WidgetBuilder<'msg, IFabDataGrid>, value: DataGridGridLinesVisibility) =
        this.AddScalar(DataGrid.GridLinesVisibility.WithValue(value))

    /// <summary>Sets the ColumnHeaderHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColumnHeaderHeight value.</param>
    [<Extension>]
    static member inline columnHeaderHeight(this: WidgetBuilder<'msg, IFabDataGrid>, value: float) =
        this.AddScalar(DataGrid.ColumnHeaderHeight.WithValue(value))

    /// <summary>Sets the ColumnWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColumnWidth value.</param>
    [<Extension>]
    static member inline columnWidth(this: WidgetBuilder<'msg, IFabDataGrid>, value: DataGridLength) =
        this.AddScalar(DataGrid.ColumnWidth.WithValue(value))

    /// <summary>Sets the ColumnWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColumnWidth value.</param>
    [<Extension>]
    static member inline columnWidth(this: WidgetBuilder<'msg, IFabDataGrid>, value: float) =
        this.AddScalar(DataGrid.ColumnWidth.WithValue(DataGridLength(value)))

    /// <summary>Sets the RowTheme property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowTheme value.</param>
    [<Extension>]
    static member inline rowTheme(this: WidgetBuilder<'msg, IFabDataGrid>, value: ControlTheme) =
        this.AddScalar(DataGrid.RowTheme.WithValue(value))

    /// <summary>Sets the CellTheme property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CellTheme value.</param>
    [<Extension>]
    static member inline cellTheme(this: WidgetBuilder<'msg, IFabDataGrid>, value: ControlTheme) =
        this.AddScalar(DataGrid.CellTheme.WithValue(value))

    /// <summary>Sets the ColumnHeaderTheme property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColumnHeaderTheme value.</param>
    [<Extension>]
    static member inline columnHeaderTheme(this: WidgetBuilder<'msg, IFabDataGrid>, value: ControlTheme) =
        this.AddScalar(DataGrid.ColumnHeaderTheme.WithValue(value))

    /// <summary>Sets the RowGroupTheme property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowGroupTheme value.</param>
    [<Extension>]
    static member inline rowGroupTheme(this: WidgetBuilder<'msg, IFabDataGrid>, value: ControlTheme) =
        this.AddScalar(DataGrid.RowGroupTheme.WithValue(value))

    /// <summary>Sets the FrozenColumnCount property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FrozenColumnCount value.</param>
    [<Extension>]
    static member inline frozenColumnCount(this: WidgetBuilder<'msg, IFabDataGrid>, value: int) =
        this.AddScalar(DataGrid.FrozenColumnCount.WithValue(value))

    /// <summary>Sets the HeadersVisibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeadersVisibility value.</param>
    [<Extension>]
    static member inline headersVisibility(this: WidgetBuilder<'msg, IFabDataGrid>, value: DataGridHeadersVisibility) =
        this.AddScalar(DataGrid.HeadersVisibility.WithValue(value))

    /// <summary>Sets the HorizontalGridLinesBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalGridLinesBrush value.</param>
    [<Extension>]
    static member inline horizontalGridLinesBrush(this: WidgetBuilder<'msg, IFabDataGrid>, value: IBrush) =
        this.AddScalar(DataGrid.HorizontalGridLinesBrush.WithValue(value))

    /// <summary>Sets the HorizontalGridLinesBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalGridLinesBrush value.</param>
    [<Extension>]
    static member inline horizontalGridLinesBrush(this: WidgetBuilder<'msg, IFabDataGrid>, value: string) =
        this.AddScalar(DataGrid.HorizontalGridLinesBrush.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the HorizontalScrollBarVisibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalScrollBarVisibility value.</param>
    [<Extension>]
    static member inline horizontalScrollBarVisibility(this: WidgetBuilder<'msg, IFabDataGrid>, value: ScrollBarVisibility) =
        this.AddScalar(DataGrid.HorizontalScrollBarVisibility.WithValue(value))

    /// <summary>Sets the AreRowGroupHeadersFrozen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AreRowGroupHeadersFrozen value.</param>
    [<Extension>]
    static member inline areRowGroupHeadersFrozen(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.AreRowGroupHeadersFrozen.WithValue(value))

    /// <summary>Sets the MaxColumnWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxColumnWidth value.</param>
    [<Extension>]
    static member inline maxColumnWidth(this: WidgetBuilder<'msg, IFabDataGrid>, value: float) =
        this.AddScalar(DataGrid.MaxColumnWidth.WithValue(value))

    /// <summary>Sets the MinColumnWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinColumnWidth value.</param>
    [<Extension>]
    static member inline minColumnWidth(this: WidgetBuilder<'msg, IFabDataGrid>, value: float) =
        this.AddScalar(DataGrid.MinColumnWidth.WithValue(value))

    /// <summary>Sets the RowBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowBackground value.</param>
    [<Extension>]
    static member inline rowBackground(this: WidgetBuilder<'msg, IFabDataGrid>, value: IBrush) =
        this.AddScalar(DataGrid.RowBackground.WithValue(value))

    /// <summary>Sets the RowBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowBackground value.</param>
    [<Extension>]
    static member inline rowBackground(this: WidgetBuilder<'msg, IFabDataGrid>, value: string) =
        this.AddScalar(DataGrid.RowBackground.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the RowHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowHeight value.</param>
    [<Extension>]
    static member inline rowHeight(this: WidgetBuilder<'msg, IFabDataGrid>, value: float) =
        this.AddScalar(DataGrid.RowHeight.WithValue(value))

    /// <summary>Sets the RowHeaderWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowHeaderWidth value.</param>
    [<Extension>]
    static member inline rowHeaderWidth(this: WidgetBuilder<'msg, IFabDataGrid>, value: float) =
        this.AddScalar(DataGrid.RowHeaderWidth.WithValue(value))

    /// <summary>Sets the SelectionMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionMode value.</param>
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, IFabDataGrid>, value: DataGridSelectionMode) =
        this.AddScalar(DataGrid.SelectionMode.WithValue(value))

    /// <summary>Sets the VerticalGridLinesBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalGridLinesBrush value.</param>
    [<Extension>]
    static member inline verticalGridLinesBrush(this: WidgetBuilder<'msg, IFabDataGrid>, value: IBrush) =
        this.AddScalar(DataGrid.VerticalGridLinesBrush.WithValue(value))

    /// <summary>Sets the VerticalGridLinesBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalGridLinesBrush value.</param>
    [<Extension>]
    static member inline verticalGridLinesBrush(this: WidgetBuilder<'msg, IFabDataGrid>, value: string) =
        this.AddScalar(DataGrid.VerticalGridLinesBrush.WithValue(value |> Color.Parse |> ImmutableSolidColorBrush))

    /// <summary>Sets the VerticalScrollBarVisibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalScrollBarVisibility value.</param>
    [<Extension>]
    static member inline verticalScrollBarVisibility(this: WidgetBuilder<'msg, IFabDataGrid>, value: ScrollBarVisibility) =
        this.AddScalar(DataGrid.VerticalScrollBarVisibility.WithValue(value))

    /// <summary>Sets the SelectedIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedIndex value.</param>
    [<Extension>]
    static member inline selectedIndex(this: WidgetBuilder<'msg, IFabDataGrid>, value: int) =
        this.AddScalar(DataGrid.SelectedIndex.WithValue(value))

    /// <summary>Sets the ClipboardCopyMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClipboardCopyMode value.</param>
    [<Extension>]
    static member inline clipboardCopyMode(this: WidgetBuilder<'msg, IFabDataGrid>, value: DataGridClipboardCopyMode) =
        this.AddScalar(DataGrid.ClipboardCopyMode.WithValue(value))

    /// <summary>Sets the AreRowDetailsFrozen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AreRowDetailsFrozen value.</param>
    [<Extension>]
    static member inline areRowDetailsFrozen(this: WidgetBuilder<'msg, IFabDataGrid>, value: bool) =
        this.AddScalar(DataGrid.AreRowDetailsFrozen.WithValue(value))

    /// <summary>Sets the RowDetailsVisibilityMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowDetailsVisibilityMode value.</param>
    [<Extension>]
    static member inline rowDetailsVisibilityMode(this: WidgetBuilder<'msg, IFabDataGrid>, value: DataGridRowDetailsVisibilityMode) =
        this.AddScalar(DataGrid.RowDetailsVisibilityMode.WithValue(value))

    /// <summary>Listens to the HorizontalScroll Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the HorizontalScroll value changes.</param>
    [<Extension>]
    static member inline onHorizontalScroll(this: WidgetBuilder<'msg, IFabDataGrid>, fn: ScrollEventArgs -> 'msg) =
        this.AddScalar(DataGrid.HorizontalScroll.WithValue(fn))

    /// <summary>Listens to the VerticalScroll Scroll event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the VerticalScroll value changes.</param>
    [<Extension>]
    static member inline onVerticalScroll(this: WidgetBuilder<'msg, IFabDataGrid>, fn: ScrollEventArgs -> 'msg) =
        this.AddScalar(DataGrid.VerticalScroll.WithValue(fn))

    /// <summary>Listens to the AutoGeneratingColumn event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is auto generated.</param>
    [<Extension>]
    static member inline onAutoGeneratingColumn(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridAutoGeneratingColumnEventArgs -> 'msg) =
        this.AddScalar(DataGrid.AutoGeneratingColumn.WithValue(fn))

    /// <summary>Listens to the BeginningEdit event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell or row begins editing.</param>
    [<Extension>]
    static member inline onBeginningEdit(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridBeginningEditEventArgs -> 'msg) =
        this.AddScalar(DataGrid.BeginningEdit.WithValue(fn))

    /// <summary>Listens to the CellEditEnded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell edit has ended.</param>
    [<Extension>]
    static member inline onCellEditEnded(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellEditEndedEventArgs -> 'msg) =
        this.AddScalar(DataGrid.CellEditEnded.WithValue(fn))

    /// <summary>Listens to the CellEditEnding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell edit is ending.</param>
    [<Extension>]
    static member inline onCellEditEnding(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellEditEndingEventArgs -> 'msg) =
        this.AddScalar(DataGrid.CellEditEnding.WithValue(fn))

    /// <summary>Listens to the CellPointerPressed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell is clicked.</param>
    [<Extension>]
    static member inline onCellPointerPressed(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridCellPointerPressedEventArgs -> 'msg) =
        this.AddScalar(DataGrid.CellPointerPressed.WithValue(fn))

    /// <summary>Listens to the ColumnDisplayIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column's DisplayIndex changes.</param>
    [<Extension>]
    static member inline onColumnDisplayIndexChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> 'msg) =
        this.AddScalar(DataGrid.ColumnDisplayIndexChanged.WithValue(fn))

    /// <summary>Listens to the ColumnReordered event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is reordered.</param>
    [<Extension>]
    static member inline onColumnReordered(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> 'msg) =
        this.AddScalar(DataGrid.ColumnReordered.WithValue(fn))

    /// <summary>Listens to the ColumnReordering event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a column is being reordered.</param>
    [<Extension>]
    static member inline onColumnReordering(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnReorderingEventArgs -> 'msg) =
        this.AddScalar(DataGrid.ColumnReordering.WithValue(fn))

    /// <summary>Listens to the CurrentCellChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the current cell changes.</param>
    [<Extension>]
    static member inline onCurrentCellChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: EventArgs -> 'msg) =
        this.AddScalar(DataGrid.CurrentCellChanged.WithValue(fn))

    /// <summary>Listens to the LoadingRow event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is loading.</param>
    [<Extension>]
    static member inline onLoadingRow(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEventArgs -> 'msg) =
        this.AddScalar(DataGrid.LoadingRow.WithValue(fn))

    /// <summary>Listens to the PreparingCellForEdit event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a cell is being prepared for editing.</param>
    [<Extension>]
    static member inline onPreparingCellForEdit(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridPreparingCellForEditEventArgs -> 'msg) =
        this.AddScalar(DataGrid.PreparingCellForEdit.WithValue(fn))

    /// <summary>Listens to the RowEditEnded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row edit has ended.</param>
    [<Extension>]
    static member inline onRowEditEnded(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEditEndedEventArgs -> 'msg) =
        this.AddScalar(DataGrid.RowEditEnded.WithValue(fn))

    /// <summary>Listens to the RowEditEnding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row edit is ending.</param>
    [<Extension>]
    static member inline onRowEditEnding(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEditEndingEventArgs -> 'msg) =
        this.AddScalar(DataGrid.RowEditEnding.WithValue(fn))

    /// <summary>Listens to the SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(DataGrid.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the Sorting event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the data is being sorted.</param>
    [<Extension>]
    static member inline onSorting(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridColumnEventArgs -> 'msg) =
        this.AddScalar(DataGrid.Sorting.WithValue(fn))

    /// <summary>Listens to the UnloadingRow event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row is unloading.</param>
    [<Extension>]
    static member inline onUnloadingRow(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowEventArgs -> 'msg) =
        this.AddScalar(DataGrid.UnloadingRow.WithValue(fn))

    /// <summary>Listens to the LoadingRowDetails event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details is loading.</param>
    [<Extension>]
    static member inline onLoadingRowDetails(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> 'msg) =
        this.AddScalar(DataGrid.LoadingRowDetails.WithValue(fn))

    /// <summary>Listens to the RowDetailsVisibilityChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details visibility changes.</param>
    [<Extension>]
    static member inline onRowDetailsVisibilityChanged(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> 'msg) =
        this.AddScalar(DataGrid.RowDetailsVisibilityChanged.WithValue(fn))

    /// <summary>Listens to the UnloadingRowDetails event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a row details is unloading.</param>
    [<Extension>]
    static member inline onUnloadingRowDetails(this: WidgetBuilder<'msg, IFabDataGrid>, fn: DataGridRowDetailsEventArgs -> 'msg) =
        this.AddScalar(DataGrid.UnloadingRowDetails.WithValue(fn))

[<Extension>]
type DataGridCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabDataGridColumn>
        (
            _: CollectionBuilder<'msg, 'marker, IFabDataGridColumn>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabDataGridColumn>
        (
            _: CollectionBuilder<'msg, 'marker, IFabDataGridColumn>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
