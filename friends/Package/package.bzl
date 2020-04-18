load(
    "@io_bazel_rules_dotnet//dotnet/private:providers.bzl",
    "DotnetLibrary",
    "DotnetResource")

_ATTRS = {
    "srcs": attr.label_list(
        allow_files = True,
        doc = """Files which should be copied into the package""",
    )
}

def _impl(ctx):
  files = []
  out = ctx.actions.declare_directory("out")
  ctx.actions.run_shell(
      outputs = [out],
      command = "mkdir " + out.path)

  for dep in ctx.attr.srcs:
    for f in dep[DotnetLibrary].runfiles.to_list():
      file = ctx.actions.declare_file(out.path + "/" + f.basename)

      ctx.actions.expand_template(
        output = file,
        template =  f,
        substitutions = {}
      )
      files.append(file)
      #print(file.basename)
   
    return [
        DefaultInfo(files = depset(files)),
    ]

deployment_package = rule(
    implementation = _impl,
    attrs = _ATTRS
)
