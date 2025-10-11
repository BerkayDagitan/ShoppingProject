import { Card, CardMedia, CardContent, Typography, CardActions, Button } from "@mui/material";
import { AddShoppingCart, Visibility } from '@mui/icons-material';
import type { IProduct } from "../../model/IProduct";
import { Link } from "react-router-dom";
import { LoadingButton } from "@mui/lab";
import { currencyTRY } from "../../utils/formatCurrency";
import { useAppDispatch, useAppSelector } from "../../hooks/hooks";
import { addItemToCart } from "../cart/cartSlice";


interface Props {
  product: IProduct;
}

export default function Product({ product }: Props) {

  const { status} = useAppSelector(state => state.cart);
  const dispatch = useAppDispatch();



  return (
    <Card sx={{ maxWidth: 450, height: '90%', display: 'flex', flexDirection: 'column', justifyContent: 'space-between' }}>
      <CardMedia sx={{ height: 160, backgroundSize: "contain", objectFit: "contain" }} image={`http://localhost:5239/images/${product.imageUrl}`}/>
      <CardContent>
        <Typography gutterBottom variant="h6" component="h2" color="text.secondary">{product.name}</Typography>
        <Typography gutterBottom variant="body2" color="secondary">{product.description}</Typography>
        <Typography gutterBottom variant="body2" color="secondary">{currencyTRY.format(product.price)}</Typography>
      </CardContent>
      <CardActions>
        <LoadingButton color="success" loading={status === "pendingAddItem" + product.id} onClick={() => dispatch(addItemToCart({ productId: product.id }))} size="small" startIcon={<AddShoppingCart />} variant="outlined">Add To Cart</LoadingButton>
        <Button component={Link} to={`/catalog/${product.id}`} variant="outlined" size="small" startIcon={<Visibility />} color="primary">View</Button>
      </CardActions>
    </Card>
  );
}