<template>
  <div class="vault-details container-fluid">
    <!-- NOTE Vault -->
    <div class="row justify-content-center my-4">
      <div class="col-10">
        <div class="card">
          <div class="card-header text-center">
            <h3>{{vault.name}}</h3>
          </div>
          <div class="card-body">
            <h5>{{vault.description}}</h5>
          </div>
          <div class="card-footer">
            <p>
            {{vaultKeeps.keeps}}
            </p>
          </div>
        </div>
      </div>
    </div>

    <!-- NOTE Keeps -->
    <Keep v-for="keep in vaultKeeps" :key="keep.id" :keepData="keep"/>
  </div>
</template>


<script>
import Keep from "../components/KeepComp.vue";
export default {
  name: "vault-details",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVault", this.$route.params.vaultId);
    this.$store.dispatch("getKeepsOnVaults", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {},
  components: { Keep }
};
</script>


<style scoped>
</style>