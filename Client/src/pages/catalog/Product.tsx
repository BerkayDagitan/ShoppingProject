import { Card, CardMedia, CardContent, Typography, CardActions, Button } from "@mui/material";
import { AddShoppingCart, Visibility } from '@mui/icons-material';
import type { IProduct } from "../../model/IProduct";
import { Link } from "react-router-dom";
import { useState } from "react";
import request from "../../api/request";
import { LoadingButton } from "@mui/lab";
import { useCartContext } from "../../context/CartContext";


interface Props {
  product: IProduct;
}

export default function Product({ product }: Props) {

  const [loading, setLoading] = useState(false);
  const {setCart} = useCartContext();

  function handleAddItem(productId : number){

    setLoading(true);

    request.Cart.addItem(productId)
    .then(cart => setCart(cart))
    .catch(error => console.log(error))
    .finally(() => setLoading(false))
  }

  return (
    <Card sx={{ maxWidth: 450, height: '90%', display: 'flex', flexDirection: 'column', justifyContent: 'space-between' }}>
      <CardMedia sx={{ height: 160, backgroundSize: "contain", objectFit: "contain" }} image={`http://localhost:5239/images/${product.imageUrl}`}/>
      <CardContent>
        <Typography gutterBottom variant="h6" component="h2" color="text.secondary">{product.name}</Typography>
        <Typography gutterBottom variant="body2" color="secondary">{product.description}</Typography>
        <Typography gutterBottom variant="body2" color="secondary">{product.price} ₺</Typography>
      </CardContent>
      <CardActions>
        <LoadingButton color="success" loading={loading} onClick={() => handleAddItem(product.id)} size="small" startIcon={<AddShoppingCart />} variant="outlined">Add To Cart</LoadingButton>
        <Button component={Link} to={`/catalog/${product.id}`} variant="outlined" size="small" startIcon={<Visibility />} color="primary">View</Button>
      </CardActions>
    </Card>
  );
}