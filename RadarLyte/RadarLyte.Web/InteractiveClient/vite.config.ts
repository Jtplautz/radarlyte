import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    https: false,
    // host: "radarlyte.web",
    // port: 3000,
    hmr: {
      host: "localhost",
    },
  },
  plugins: [vue()],
});
