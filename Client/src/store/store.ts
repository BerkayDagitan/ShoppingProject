import { configureStore } from '@reduxjs/toolkit';
import { cartSlice } from '../features/cart/cartSlice';
import { catalogSlice } from '../features/catalog/catalogSlice';
import { accountSlice } from '../features/account/accountSlice';

export const store = configureStore({
  reducer: {
    cart: cartSlice.reducer,
    catalog: catalogSlice.reducer,
    account: accountSlice.reducer
  }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
