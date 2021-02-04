using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    private int color;
    private Vector2 pos;
    private Vector2 size;

    public Tile( int _posX, int _posY, int _color, int _sizeX, int _sizeY ) {
        SetPos( _posX, _posY );
        SetColor( _color );
        SetSize( _sizeX, _sizeY );
    }

    public Tile( Vector2 _pos, int _color, Vector2 _size ) {
        SetPos( _pos );
        SetColor( _color );
        SetSize( _size );
    }

    public void SetPos( int _posX, int _posY ) {
        pos.x = _posX;
        pos.y = _posY;
    }

    public void SetPos( Vector2 _pos ) {
        pos = _pos;
    }

    public void SetColor( int _color ) {
        color = _color;
    }

    public void SetSize( int _sizeX, int _sizeY ) {
        size.x = _sizeX;
        size.y = _sizeY;
    }

    public void SetSize( Vector2 _size ) {
        size = _size;
    }
}
