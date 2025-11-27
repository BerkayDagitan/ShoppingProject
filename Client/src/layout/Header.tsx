import ShoppingCart from "@mui/icons-material/ShoppingCart";
import { AppBar, Badge, Box, Button, IconButton, Stack, Toolbar, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import { NavLink } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../hooks/hooks";
import { logout } from "../features/account/accountSlice";

const links = [
  { title: 'Home', to: '/' },
  { title: 'About', to: '/about' },
  { title: 'Contact', to: '/contact' },
  { title: 'Catalog', to: '/catalog' },
  { title: 'Error', to: '/error' }
];

const authLinks = [
  { title: "Login", to: "/login" },
  { title: "Register", to: "/register" }
]

const navStyles = {
  color: 'inherit',
  textDecoration: 'none',
  "&:hover": {
    color: "text.primary"
  },
  "&.active": {
    color: "warning.main"
  }
}

export default function Header() {
  const { cart } = useAppSelector(state => state.cart)
  const { user } = useAppSelector(state => state.account)
  const dispatch = useAppDispatch();

  const itemCount = cart?.cartItems?.reduce((total, item) => total + item.quantity, 0) ?? 0;

  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
        <Box sx={{ display: 'flex', alignItems: 'center' }}>
          <Typography variant="h6">E-Commerce</Typography>
          <Stack direction={"row"}>
            {links.map(link =>
              <Button key={link.to} component={NavLink} to={link.to} sx={navStyles}>{link.title}</Button>
            )}
          </Stack>
        </Box>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 2, flexWrap: 'nowrap' }}>
          <IconButton component={Link} to="/cart" size="large" edge="start" color="inherit">
            <Badge badgeContent={itemCount} color="secondary">
              <ShoppingCart />
            </Badge>
          </IconButton>
          {
            user ? (
              <Stack direction="row">
                <Button sx={navStyles}>Welcome, {user.name}</Button>
                <Button sx={navStyles} onClick={() => dispatch(logout())}>Log Out</Button>
              </Stack>
            ) : (
              <Stack direction={"row"}>
                {authLinks.map(link =>
                  <Button key={link.to} component={NavLink} to={link.to} sx={navStyles}>{link.title}</Button>
                )}
              </Stack>
            )
          }
        </Box>
      </Toolbar>
    </AppBar>
  );
}