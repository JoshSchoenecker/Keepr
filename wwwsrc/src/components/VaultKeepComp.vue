<template>
  <div class="vault-keep">
      <div class="col-sm-10 col-lg-4">
          <!-- <div v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">
            <keep/>
          </div> -->
          <!-- TODO ask  -->
      </div>
  </div>
</template>


<script>
import Keep from "../components/KeepComp.vue"
export default {
  name: "vault-keep",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepsOnVaults", this.$route.params.vaultId);
  },
  computed: {
      vaultKeeps(){
          return this.$store.state.vaultKeeps
      }
  },
  methods: {},
  components: {Keep}
};
</script>


<style scoped>
</style>