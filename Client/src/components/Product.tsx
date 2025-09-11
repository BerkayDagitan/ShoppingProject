import type { IProduct } from "../model/IProduct";
import { Card, CardMedia, CardContent, Typography, CardActions, Button } from "@mui/material";
import { AddShoppingCart, Visibility } from '@mui/icons-material';

interface Props {
  product: IProduct;
}

export default function Product({ product }: Props) {
  return (
    <Card sx={{ maxWidth: 450, height: '90%', display: 'flex', flexDirection: 'column', justifyContent: 'space-between' }}>
      <CardMedia sx={{ height: 160, backgroundSize: "contain", objectFit: "contain" }} image={`http://localhost:5239/images/${product.imageUrl}`}/>
      <CardContent>
        <Typography gutterBottom variant="h6" component="h2" color="text.secondary">{product.name}</Typography>
        <Typography gutterBottom variant="body2" color="secondary">{product.description}</Typography>
        <Typography gutterBottom variant="body2" color="secondary">{product.price} ₺</Typography>
      </CardContent>
      <CardActions>
        <Button variant="outlined" size="small" startIcon={<AddShoppingCart />} color="success">Sepete Ekle</Button>
        <Button variant="outlined" size="small" startIcon={<Visibility />} color="primary">Detayları Görüntüle</Button>
      </CardActions>
    </Card>
  );
}