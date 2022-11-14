import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.ImageObserver;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class PictureBox extends JPanel implements MouseListener, MouseMotionListener{
    public static final int AUTO_SCALE = 100;
    public static final int AUTO_SCALE_WIDTH = 101;
    public static final int AUTO_SCALE_HEIGHT = 102;
    public static final int WITHOUT_SCALING = 103;

    private Image image;
    private Image buffed_image;
    private Image cuted_image;
    private Image inserted_image;
    Graphics rect_graphics;
    private int cut_rect_width;
    private int cut_rect_height;

    private int scale_mode;

    private int image_draw_width;
    private int image_draw_height;

    private int print_x;
    private int print_y;

    private int paste_x;
    private int paste_y;
    private int paste_width;
    private int paste_height;

    private int old_x, old_y;
    private int new_x, new_y;

    public PictureBox(){
        scale_mode = WITHOUT_SCALING;
        print_x = 0;
        print_y = 0;
        image = null;
        image_draw_height = 0;
        image_draw_width = 0;
    }

    public PictureBox(String image_path) {
        scale_mode = AUTO_SCALE;
        print_x = 0;
        print_y = 0;

        try {
            image = ImageIO.read(new File(image_path));
            image_draw_width = image.getWidth(getFocusCycleRootAncestor());
            image_draw_height = image.getHeight(getFocusCycleRootAncestor());
            // crop_x = 0;
            // crop_y = 0;
            // crop_width = image.getWidth(getFocusCycleRootAncestor());
            // crop_height = image.getHeight(getFocusCycleRootAncestor());
        }
        catch (IOException e) {
            System.err.print("Can't find image " + image_path);
        }

        buffed_image = image;

        addMouseListener(this);
        addMouseMotionListener(this);
    }

    public Image getCutedImage(){
        return cuted_image;
    }

    public Point getCutRectangle(){
        Point point = new Point(cut_rect_width, cut_rect_height);
        return point;
    }

    public void setImage(Image image){
        this.image = image;
        scale_mode = AUTO_SCALE;
        repaint();
    }

    public void setGeometry(int width, int height){
        image_draw_width = width;
        image_draw_height = height;
    }

    public void setScale(int scale_code){
        switch (scale_code){
            case AUTO_SCALE:
                scale_mode = AUTO_SCALE;
                break;
            case AUTO_SCALE_WIDTH:
                scale_mode = AUTO_SCALE_WIDTH;
                break;
            case AUTO_SCALE_HEIGHT:
                scale_mode = AUTO_SCALE_HEIGHT;
                break;
            default:
                scale_mode = WITHOUT_SCALING;
                break;
        }
    }

    private void _calculateAutoScaleWidthAndSet(){
        if (image == null) {return;}
        image_draw_height = (int)Math.round(image.getHeight(getFocusCycleRootAncestor())*this.getWidth()/image.getWidth(getFocusCycleRootAncestor())); 
        image_draw_width = (int)Math.round(image.getWidth(getFocusCycleRootAncestor())*image_draw_height/image.getHeight(getFocusCycleRootAncestor())); 
    }

    private void _calculateAutoScaleHeightAndSet(){
        if (image == null) {return;}
        image_draw_width = (int)Math.round(image.getWidth(getFocusCycleRootAncestor())*this.getHeight()/image.getHeight(getFocusCycleRootAncestor())); 
        image_draw_height = (int)Math.round(image.getHeight(getFocusCycleRootAncestor())*image_draw_width/image.getWidth(getFocusCycleRootAncestor())); 
    }

    private void _scale(){
        if (image_draw_height == this.getHeight() && image_draw_width == this.getWidth()) {return;}
        switch (scale_mode){
            case AUTO_SCALE:
                if (this.getHeight() > this.getWidth()){
                    _calculateAutoScaleWidthAndSet();
                }
                else{
                    _calculateAutoScaleHeightAndSet();
                }
            break;
            case AUTO_SCALE_WIDTH:
                _calculateAutoScaleWidthAndSet();
                break;
            case AUTO_SCALE_HEIGHT:
                _calculateAutoScaleHeightAndSet();
                break;
            default:
                throw new IllegalArgumentException("Scale mode " + scale_mode + " not found!");
        }
        this.setBounds(this.getX(), this.getY(), image_draw_width, image_draw_height);
    }

    public void setCoordinates(int x, int y){
        if (x < 0 || y < 0) {
            throw new IllegalArgumentException();
        }
        print_x = x;
        print_y = y;
    }

    private void cutoutFromImage(){
        BufferedImage temp = (BufferedImage) image;
        double field_ratio_width;
        double field_ratio_height;
        if (image.getWidth(getFocusCycleRootAncestor()) > this.getWidth()){
            field_ratio_width = (double)image.getWidth(null)/(double)this.getWidth();
        }
        else{
            field_ratio_width = (double)this.getWidth()/(double)image.getHeight(getFocusCycleRootAncestor());
        }

        if (image.getHeight(getFocusCycleRootAncestor()) > this.getHeight()){
            field_ratio_height = (double)image.getHeight(null)/(double)this.getHeight();
        }
        else{
            field_ratio_height = (double)this.getHeight()/(double)image.getHeight(getFocusCycleRootAncestor());
        }
        int cx = (int)(field_ratio_width*old_x);
        int cy = (int)(field_ratio_height*old_y);
        int cw = (int)(field_ratio_width*new_x);
        int ch = (int)(field_ratio_height*new_y);
        if (new_x < old_x && new_y < old_y){
            cuted_image = temp.getSubimage(cw, ch, cx-cw, cy-ch);
        }
        else if(new_x < old_x){
            cuted_image = temp.getSubimage(cw, cy, cx-cw, ch-cy);
        }
        else if(new_y < old_y){
            cuted_image = temp.getSubimage(cx, ch, cw-cx, cy-ch);
        }
        else{
            cuted_image = temp.getSubimage(cx, cy, cw-cx, ch-cy);
        }
    }

    @Override
    public void mousePressed(MouseEvent e) {
        old_x = e.getX();
        old_y = e.getY();
        rect_graphics = this.getGraphics();
        buffed_image = image;
    }

    @Override
    public void mouseReleased(MouseEvent e) {
        new_x = e.getX();
        new_y = e.getY();
        if (new_x < old_x && new_y < old_y){
            cut_rect_height = old_y-new_y;
            cut_rect_width = old_x-new_x;
        }
        else if(new_x < old_x){
            cut_rect_height = new_y-old_y;
            cut_rect_width = old_x-new_x;
        }
        else if(new_y < old_y){
            cut_rect_height = old_y-new_y;
            cut_rect_width = new_x-old_x;
        }
        else{
            cut_rect_height = new_y-old_y;
            cut_rect_width = new_x-old_x;
        }
        cutoutFromImage();
        image = buffed_image;
    }

    @Override
    public void mouseDragged(MouseEvent e) {
        new_x = e.getX();
        new_y = e.getY();
        rect_graphics.clearRect(0, 0, this.getWidth(), this.getHeight());
        _paint(rect_graphics);
        rect_graphics = this.getGraphics();
        rect_graphics.setColor(Color.WHITE);
        if (new_x < old_x && new_y < old_y){
            rect_graphics.drawRect(new_x, new_y, old_x-new_x, old_y-new_y);
        }
        else if(new_x < old_x){
            rect_graphics.drawRect(new_x, old_y, old_x-new_x, new_y-old_y);
        }
        else if(new_y < old_y){
            rect_graphics.drawRect(old_x, new_y, new_x-old_x, old_y-new_y);
        }
        else{
            rect_graphics.drawRect(old_x, old_y, new_x-old_x, new_y-old_y);
        }
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        _scale();
        _paint(g);
    }

    public void insertImage(String image_path, int paste_x, int paste_y, int paste_width, int paste_height, int crop_x, int crop_y, int crop_width, int crop_height){
        Image temp_image;
        try {
            temp_image = ImageIO.read(new File(image_path));
        }
        catch (IOException e) {
            System.err.print("Can't find image " + image_path);
            return;
        }
        this.paste_x = paste_x;
        this.paste_y = paste_y;
        this.paste_width = paste_width;
        this.paste_height = paste_height;
        BufferedImage temp = (BufferedImage) temp_image;
        temp_image = temp.getSubimage(crop_x, crop_y, crop_width, crop_height);
        inserted_image = temp_image;
    }

    private void _paint(Graphics g){
        g.drawImage(image, print_x, print_y, image_draw_width, image_draw_height, new ImageObserver() {
            @Override
            public boolean imageUpdate(Image img, int infoflags, int x, int y, int width, int height) {
                return false;
            }
        });
        if (inserted_image == null) {return;}
        g.drawImage(inserted_image, paste_x, paste_y, paste_width, paste_height, null);
    }

    
    @Override
    public void mouseClicked(MouseEvent e) {
        repaint();
    }

    @Override
    public void mouseEntered(MouseEvent e) {
        
    }

    @Override
    public void mouseExited(MouseEvent e) {
        
    }

    @Override
    public void mouseMoved(MouseEvent e){

    }
}
