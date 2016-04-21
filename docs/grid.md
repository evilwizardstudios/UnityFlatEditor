!!! note "OnGUI()"
    All FlatEditor code must be called in the OnGUI() method of an EditorWindow or
    Inspector.

# Containers
Flat Editor replicates the responsive Bootstrap grid. Grids lay out window or
inspector content in columns and rows:

```csharp
void OnGUI()
{
  Row.Start();

    var columnA = new Column(6,0);
    var columnB = new Column(6,0);

    columnA.Start();
      Typography.Title("This is Column A");
    columnA.End();

    columnB.Start();
      Typography.Title("This is Column B");
    columnB.End();

  Row.End();
}
```



## Rows
Rows are parent containers for columns, they track column position
(GUILayoutOption won't work for our columns) and enforce horizontal margins.

Rows will automatically break if a line of columns extends beyond 12 units.
However, the rows never "lose" column references - they preserve column
lengths.

Rows are opened and closed by static functions ``Row.Start()`` and ``Row.End()``
Rows **must** be closed with ``Row.End()`` or Unity will throw a GUI error.

**Rows cannot be nested**

```csharp
void OnGUI()
{
  Row.Start();
    //Row content
  Row.End();
}
```

## Columns
Columns are objects that handle automatic layout-ing of GUI content,
arranging the stuff in them into neat, regular columns. By default, columns are
described in units of width out of 12 (like Bootstrap), and are *reactive*, meaning
they will change their width based on window size.

Columns take two ``bytes`` as parameters in their constructor. The first is the
**width** value of the column: how many units (out of 12) the column content will
cover. The second is the **offset** value of the column: how many column units of
blank space will precede the column. A column's width and offset combined *cannot
exceed 12*.

```csharp
//This column's content will span the entire Row
var fullColumn = new Column(12,0);

//This columns's content will span the left half of the Row
var halfColumn = new Column(6,0);

//This column's content will span the right half of the Row
var offsetColumn = new Column(6,6);

//This column's content will span the middle third of the Row
var middleColumn = new Column(4,4);

//This column's width + offset = 16, so Flat Editor will throw an error
var invalidColumn = new Column(8,8);
```

Columns react to [window size breakpoints](customize#breakpoints), and can have
specific widths per breakpoint. These widths are set by the ``SetSize`` method,
which takes three parameters: a ``ScreenSize`` breakpoint, a width ``byte``, and
an offset ``byte``:

```csharp
var myColumn = new Column(8, 4);

myColumn.SetSize(ScreenSize.xs, 12, 0);
```
``myColumn`` will be 8 units wide and have an offset of 4 when the window width
is larger than the *xs* breakpoint (768px by default). If the window width is
*less than* the *xs* breakpoint, the column will be 12 units wide with no offset.

Columns must ``.Start()`` and ``.End()`` within a [Row](#Rows).

## Grid
The Grid is a utility class that manages the grid, but also contains static methods
that can can return useful information, specifically:

```csharp
// Returns the currently active Row
Grid.OpenRow()

// Returns the current ScreenSize, based on breakpoint
Grid.CurrentScreenSize()
```

``CurrentScreenSize()`` is useful as a way to change grid content based on ScreenSize
(reducing font size or abbreviating a label, for example).


# Forms

# Charts

# Panels

## Alerts

## Wells

# Buttons

## Dropdowns

## Tooltips

## Popovers

# Navs

# Pagination

# Badges

# Bars

## Progress Bars

# Objects
