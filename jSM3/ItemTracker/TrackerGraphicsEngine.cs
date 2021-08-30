using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using jSM3.Constants;
using jSM3.ItemTracker.Adapters;
using jSM3.ItemTracker.Models;
// ReSharper disable ArrangeRedundantParentheses
// ReSharper disable RedundantExplicitArrayCreation

namespace jSM3.ItemTracker
{
    public class TrackerGraphicsEngine
    {
        //todo: customize this default background from user preference
        private readonly Color _defaultBackground = Color.FromArgb(0x5A, 0x5A, 0x0);
        

        private readonly GraphicsAdapter _formGraphics;

        private readonly List<SmItem> _smItems;
        
        private readonly List<Bitmap> _smItemImages = new();

        private List<Rectangle> _itemSlots = new();


        private readonly ColorMatrix _greyscaleColorMatrix = new(
            new float[][]
            {
                new float[] {.1f, .1f, .1f, 0, 0},
                new float[] {.3f, .3f, .3f, 0, 0},
                new float[] {.1f, .1f, .1f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            }
        );

        public TrackerGraphicsEngine(GraphicsAdapter formGraphics, List<SmItem> smItems)
        {
            _formGraphics = formGraphics ?? throw new ArgumentNullException(nameof(formGraphics));
            _smItems = smItems ?? throw new ArgumentNullException(nameof(smItems));

            LoadImages();
        }
        
        
        private const int ImageSize = 16;
        private const int CellPadding = 1;
        private const int Columns = 8;
        private const int CellSize = ImageSize + CellPadding;
        public void CalculateGrid(int baseWidth, int baseHeight)
        {
            int scale = 1;
            int adjustedColumns = (int)(Columns * (baseWidth / (float)baseHeight));

            // if (adjustedColumns < 4) adjustedColumns = 4;

            int itemCount = _smItems.Count;

            int normalItemsRows = (int)Math.Ceiling((float)(itemCount + 1) / adjustedColumns);
            int cellsPerColumn = baseHeight / ((CellSize * (2 + normalItemsRows)) );
            int cellsPerRow = baseWidth / ((CellSize * adjustedColumns) + (CellPadding * scale));

            scale = cellsPerColumn <= cellsPerRow ? cellsPerColumn : cellsPerRow;
            
            _itemSlots = new List<Rectangle>();

            int row = 0;
            int col = 0;

            for (int i = 0; i < itemCount + 1; i++)
            {
                if (col == adjustedColumns)
                {
                    row++;
                    col = 0;
                }
                _itemSlots.Add(
                    new Rectangle(
                        (CellPadding * scale) + (col * (ImageSize + CellPadding) * scale),
                        row * (ImageSize + CellPadding) * scale,
                        ImageSize * scale,
                        ImageSize * scale
                    )
                );
                col++;
            }
        }

        public void Render()
        {
            ImageAttributes greyscaleAttributes = new();
            greyscaleAttributes.SetColorMatrix(_greyscaleColorMatrix);
            
            _formGraphics.Clear(_defaultBackground);

            int drawnItemsCounter = 0;
            for (int i = 0; i < 16; i++)
            {
                if (_smItems[i].Owned)
                {
                    _formGraphics.DrawImage(
                        _smItemImages[i],
                        _itemSlots[drawnItemsCounter],
                        0, 
                        0,
                        _smItemImages[i].Width,
                        _smItemImages[i].Height,
                        GraphicsUnit.Pixel
                    );
                    
                    if(_smItems[i].Equipped) _formGraphics.DrawItemEquippedCircle(_itemSlots[drawnItemsCounter]);
                }
                else
                {
                    _formGraphics.DrawImage(
                        _smItemImages[i], 
                        _itemSlots[drawnItemsCounter],
                        0, 
                        0,
                        _smItemImages[i].Width,
                        _smItemImages[i].Height,
                        GraphicsUnit.Pixel,
                        greyscaleAttributes
                    );
                }
                drawnItemsCounter++;
            }
        }
        


        private void LoadImages()
        {
            foreach (SmItem item in _smItems)
            {
                _smItemImages.Add(new Bitmap(Image.FromFile(Paths.ImagesPath + item.Name + ".gif")));
            }
        }
    }
}